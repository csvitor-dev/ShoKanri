using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class RegisterAccountUC(
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRegisterAccountUC
    {
        public async Task<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest request)
        {
            await ValidateAsync(request);

            var account = mapper.Map<Domain.Entities.Account>(request);

            await writeRepo.CreateAsync(account);

            await unitOfWork.CommitAsync();

            return new RegisterAccountResponse(request.UserId, account.Name!);
        }


        private static async Task ValidateAsync(RegisterAccountRequest registerAccountRequest)
        {

            var result = await new RegisterAccountValidator().ValidateAsync(registerAccountRequest);


            if (result.IsValid)
                return;

            var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();
        }
    }
}