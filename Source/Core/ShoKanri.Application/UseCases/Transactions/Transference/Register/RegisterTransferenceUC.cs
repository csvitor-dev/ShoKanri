using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Http.Responses.Transaction;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Register
{
    public class RegisterTransferenceUC(
        ITransactionWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : UseCase<RegisterTransferenceRequest>(new RegisterTransferenceValidator()), IRegisterTransferenceUC
    {
        public async Task<TransactionResponse> RegisterTransference(RegisterTransferenceRequest request)
        {
            await ValidateAsync(request);

            var transference = mapper.Map<Domain.Entities.Transactions.Transference>(request);

            await writeRepo.CreateAsync(transference);
            await unitOfWork.CommitAsync();

            return new TransactionResponse(transference.Id, transference.Amount, request.Type, DateTime.Now);
        }
    }
}