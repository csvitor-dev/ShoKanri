using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transference.Update
{
    public interface IUpdateTransferenceUC
    {
        public Task<TransactionResponse> UpdateTransference(UpdateTransferenceRequest request);
    }
}