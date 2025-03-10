using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Delete
{
    public interface IDeleteIncomeUC
    {
        public Task<TransactionResponse> DeleteIncome(DeleteTransactionRequest request);

    }
}