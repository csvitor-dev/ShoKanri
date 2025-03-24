using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Delete
{
    public class DeleteTransferenceUC
    (
        ITransactionWriteRepository writeRepo,
        ITransactionReadRepository readRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IDeleteTransferenceUC
    {
        public async Task<TransactionResponse> DeleteTransference(int id, int accountId)
        {

            await writeRepo.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            var transference = await readRepo.FindByIdAsync(id, accountId);
            var response = mapper.Map<TransactionResponse>(transference);

            return response;
        }
    }
}