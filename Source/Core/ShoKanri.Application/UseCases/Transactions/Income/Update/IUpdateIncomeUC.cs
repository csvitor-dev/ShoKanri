using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Update
{
    public interface IUpdateIncomeUC
    {
        public Task<TransactionResponse> UpdateExpense(UpdateTransactionRequest request);

    }
}