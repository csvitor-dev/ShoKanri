using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public class GetAllTransferencesUC : IGetAllTransferencesUC
    {
        public Task<TransactionResponse> GetAllTransference(GetAllTransferenceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}