using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Register
{
    public interface IRegisterExpenseUC
    {
        public Task<TransactionResponse> RegisterExpense(RegisterTransactionRequest request);
    }
}