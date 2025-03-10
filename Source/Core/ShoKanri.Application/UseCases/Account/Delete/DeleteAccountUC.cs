using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public class DeleteAccountUC(
        IAccountReadRepository readRepo,
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork
    ) : IDeleteAccountUC
    {
        public Task<DeleteAccountResponse> DeleteAccount(DeleteAccountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}