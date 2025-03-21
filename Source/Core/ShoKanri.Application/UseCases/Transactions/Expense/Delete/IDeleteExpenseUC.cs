using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Delete
{
    public interface IDeleteExpenseUC
    {
        public Task<TransactionResponse> DeleteExpense(int Id, int AccountId);

    }
}