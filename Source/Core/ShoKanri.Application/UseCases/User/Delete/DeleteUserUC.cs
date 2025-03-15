using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Delete
{
    public class DeleteUserUC(
        IUserWriteRepository writeRepo,
        IUnitOfWork unitOfWork
    ) : IDeleteUserUC
    {
        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request)
        {
            await ValidateAsync(request);

            await writeRepo.DeleteAsync(request.Id);
            await unitOfWork.CommitAsync();

            return new DeleteUserResponse(request.Id);
        }


        private static async Task ValidateAsync(DeleteUserRequest deleteUserRequest)
        {

            var result = await new DeleteUserValidator().ValidateAsync(deleteUserRequest);

            if (result.IsValid) return;



        }

    }
}