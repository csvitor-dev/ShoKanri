using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Update
{
    public interface IUpdateTransferenceUC
    {
        public Task<TransactionResponse> UpdateTransference(UpdateTransferenceRequest request);
    }
}