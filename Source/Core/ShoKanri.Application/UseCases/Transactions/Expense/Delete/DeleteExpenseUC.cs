using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Delete
{
    public class DeleteExpenseUC : IDeleteExpenseUC
    {
        public Task<TransactionResponse> DeleteExpense(DeleteTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}