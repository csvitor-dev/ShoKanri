using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public class DeleteAccountUC(
        IAccountWriteRepository writeRepo,
        IAccountReadRepository readRepo,
        IUnitOfWork unitOfWork
    ) : IDeleteAccountUC
    {
        public async Task<DeleteAccountResponse> DeleteAccount(int Id, int UserId)
        {

            var account = await readRepo.FindByIdAsync(Id, UserId) ?? 
                throw new System.Exception("Conta não encontrada");
            
            await writeRepo.DeleteAsync(Id);
            await unitOfWork.CommitAsync();

            return new DeleteAccountResponse(account.Id, account.Name!);
        }


    }
}