using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Update
{
    public class UpdateTransferenceUC(
        ITransactionWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : UseCase<UpdateTransferenceRequest>(new UpdateTransferenceValidator()), IUpdateTransferenceUC
    {
        public async Task<TransactionResponse> UpdateTransference(UpdateTransferenceRequest request)
        {
            await ValidateAsync(request);

            var transferece = mapper.Map<Domain.Entities.Transactions.Transference>(request);

            await writeRepo.UpdateAsync(transferece);
            await unitOfWork.CommitAsync();

            var response = mapper.Map<TransactionResponse>(transferece);

            return response;

        }
    }
}