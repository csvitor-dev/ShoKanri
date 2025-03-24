using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Delete;

public class DeleteUserUC
(
    IUserWriteRepository writeRepo,
    IUnitOfWork unitOfWork
) : IDeleteUserUC
{
        public async Task<DeleteUserResponse> DeleteUser(int id)
        {
            await writeRepo.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return new DeleteUserResponse(id);
        }
}