using AutoMapper;
using ShoKanri.Application.Services;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Http.Dto;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Login;

public class LoginUserUC
(
    IUserReadRepository readRepo,
    IMapper mapper,
    PasswordEncryptionService service
) : UseCase<LoginUserRequest>(new LoginUserValidator()), ILoginUserUC
{
    public async Task<LoginUserDto> LoginUser(LoginUserRequest request)
    {
        await ValidateAsync(request);

        var user = await readRepo.FindByEmailAsync(request.Email);

        return mapper.Map<LoginUserDto>(user);
    }

    protected override async Task<string> ApplyExtraValidationAsync(LoginUserRequest request)
    {
        var password = service.Encrypt(request.Password);
        var user = await readRepo.FindByEmailAsync(request.Email);

        return password != user?.Password
            ? "The credentials provided aren't valid!"
            : string.Empty;
    }
}
