using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Expense.Register
{
    public interface IRegisterExpenseUC
    {
        public Task<TransactionResponse> RegisterExpense(RegisterTransactionRequest request);
    }
}