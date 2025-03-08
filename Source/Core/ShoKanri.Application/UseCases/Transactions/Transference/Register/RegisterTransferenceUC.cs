using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Http.Responses.Transaction;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transference.Register
{
    public class RegisterTransferenceUC(
        ITransactionReadRepository readRepo,
        ITransactionWriteRepository writeRepo,
        IAccountReadRepository accountReadRepo,
        IAccountWriteRepository accountWriteRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRegisterTransferenceUC
    {
        public Task<TransactionResponse> CreateTransference(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}