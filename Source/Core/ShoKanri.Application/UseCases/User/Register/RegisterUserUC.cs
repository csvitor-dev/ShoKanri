using AutoMapper;
using ShoKanri.Application.Services;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Register
{
    public class RegisterUserUC(
        IUserReadRepository readRepo,
        IUserWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        PasswordEncryptionService service
    ) : IRegisterUserUC
    {
        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            await ValidateAsync(request);

            var user = mapper.Map<Domain.Entities.User>(request);
            user.Password = service.Encrypt(request.Password);

            await writeRepo.CreateAsync(user);
            await unitOfWork.CommitAsync();

            return new RegisterUserResponse(user.Id);
        }


        private async Task ValidateAsync(RegisterUserRequest request)
        {

            var result = await new RegisterUserValidator().ValidateAsync(request);
            var emailExists = await readRepo.FindActiveEmailAsync(request.Email);

            if (result.IsValid && emailExists is false)
                return;

            var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

            throw new InvalidOperationException(errorMessages[0]);
        }
    }
}
