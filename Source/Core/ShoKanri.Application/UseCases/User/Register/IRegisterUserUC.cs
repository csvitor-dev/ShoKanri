using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Register
{
    public interface IRegisterUserUC
    {
        public Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
    }
}