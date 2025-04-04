using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.GetAll
{
    public interface IGetAllExpensesUC
    {
        public Task<IList<TransactionResponse>> GetAllExpense(int accountId);
    }
}