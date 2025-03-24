using System.Net;
using AutoMapper;
using ShoKanri.Application.Services;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Exception.Base;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Register;

public class RegisterUserUC
(
    IUserReadRepository readRepo,
    IUserWriteRepository writeRepo,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    PasswordEncryptionService service
) : UseCase<RegisterUserRequest>(new RegisterUserValidator()), IRegisterUserUC
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

    protected override async Task<string> ApplyExtraValidationAsync(RegisterUserRequest request)
    {
        var emailExists = await readRepo.FindActiveEmailAsync(request.Email);

        return emailExists is true
            ? "Email already exists on database."
            : string.Empty;
    }
}
