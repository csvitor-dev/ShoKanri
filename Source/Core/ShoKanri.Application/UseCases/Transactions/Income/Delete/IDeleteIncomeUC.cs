using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Delete
{
    public interface IDeleteIncomeUC
    {
        public Task<TransactionResponse> DeleteIncome(DeleteTransactionRequest request);

    }
}