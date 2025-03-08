using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public class DeleteAccountUC (
        IAccountReadRepository readRepo,
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork
    ): IDeleteAccountUC
    {
        
    }
}