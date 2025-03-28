using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Register
{
    public interface IRegisterIncomeUC
    {
        public Task<TransactionResponse> RegisterIncome(RegisterTransactionRequest request);

    }
}