using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.GetAll
{
    public class GetAllExpensesUC : IGetAllExpensesUC
    {
        public Task<TransactionResponse> GetAllExpense(GetAllTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}