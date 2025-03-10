using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Delete{
    public interface IDeleteTransferenceUC
    {
        public Task<TransactionResponse> DeleteTransference(DeleteTransferenceRequest request);

    }
}