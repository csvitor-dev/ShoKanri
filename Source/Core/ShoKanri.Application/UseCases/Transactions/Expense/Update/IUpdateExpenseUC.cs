using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Update
{
    public interface IUpdateExpenseUC
    {
        public Task<TransactionResponse> UpdateExpense(UpdateTransactionRequest request);

    }
}