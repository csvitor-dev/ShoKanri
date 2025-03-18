using AutoMapper;
using ShoKanri.Application.Services;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Http.Dto;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Login;

public class LoginUserUC(IUserReadRepository readRepo, IMapper mapper, PasswordEncryptionService service) : ILoginUserUC
{
    public async Task<LoginUserDto> LoginUser(LoginUserRequest request)
    {
        await ValidateAsync(request);

        var password = service.Encrypt(request.Password);
        var user = await readRepo.FindByEmailAsync(request.Email);

        if (user is null || password != user.Password)
            throw new InvalidOperationException("The credentials provided aren't valid!");


        return mapper.Map<LoginUserDto>(user);
    }

    private static async Task ValidateAsync(LoginUserRequest request)
    {

        var result = await new LoginUserValidator().ValidateAsync(request);

        if (result.IsValid)
            return;

        var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();
    }
}
