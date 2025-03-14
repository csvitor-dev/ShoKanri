using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Delete
{
    public interface IDeleteUserUC
    {
        public Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request);

    }
}