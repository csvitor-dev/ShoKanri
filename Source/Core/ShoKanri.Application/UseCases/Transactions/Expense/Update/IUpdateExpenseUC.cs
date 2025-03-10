using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Expense.Update
{
    public interface IUpdateExpenseUC
    {
        public Task<TransactionResponse> UpdateExpense(UpdateTransactionRequest request);

    }
}