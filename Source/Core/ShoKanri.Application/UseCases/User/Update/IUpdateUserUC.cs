using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Update
{
    public interface IUpdateUserUC
    {
        public Task<UpdateUserResponse> UpdateUser(int id, UpdateUserRequest request);
    }
}