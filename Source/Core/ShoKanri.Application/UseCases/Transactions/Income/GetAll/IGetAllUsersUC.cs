using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.GetAll
{
    public interface IGetAllIncomesUC
    {
        public Task<IList<TransactionResponse>> GetAllExpense(int AccountId);

    }
}