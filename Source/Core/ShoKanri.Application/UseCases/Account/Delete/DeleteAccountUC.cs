using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Delete;

public class DeleteAccountUC
(
    IAccountWriteRepository writeRepo,
    IAccountReadRepository readRepo,
    IUnitOfWork unitOfWork
) : IDeleteAccountUC
{
    public async Task<DeleteAccountResponse> DeleteAccount(int id, int userId)
    {

        var account = await readRepo.FindByIdAsync(id, userId) ??
            throw new ErrorOnValidationException("conta não encontrada");

        await writeRepo.DeleteAsync(id);
        await unitOfWork.CommitAsync();

        return new DeleteAccountResponse(account.Id, account.Name!);
    }
}