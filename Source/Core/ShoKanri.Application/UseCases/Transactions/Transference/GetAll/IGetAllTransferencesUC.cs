using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public interface IGetAllTransferencesUC
    {
        public Task<IList<TransactionResponse>> GetAllTransferences(int accountId);
    }
}