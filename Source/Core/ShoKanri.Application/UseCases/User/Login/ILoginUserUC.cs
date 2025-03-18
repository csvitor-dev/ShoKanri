using ShoKanri.Http.Dto;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Login;

public interface ILoginUserUC
{
    public Task<LoginUserDto> LoginUser(LoginUserRequest request);
}