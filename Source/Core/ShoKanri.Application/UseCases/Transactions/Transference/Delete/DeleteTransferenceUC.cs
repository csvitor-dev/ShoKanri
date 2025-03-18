using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Delete
{
    public class DeleteTransferenceUC(
        ITransactionWriteRepository writeRepo,
        ITransactionReadRepository readRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper

    ) : IDeleteTransferenceUC
    {
        public async Task<TransactionResponse> DeleteTransference(DeleteTransferenceRequest request)
        {
            await ValidateAsync(request);

            await writeRepo.DeleteAsync(request.Id);
            await unitOfWork.CommitAsync();

            var expense = await readRepo.FindByIdAsync(request.Id, request.AccountId);
            var response = mapper.Map<TransactionResponse>(expense);
            return response;
        }

         private static async Task ValidateAsync(DeleteTransferenceRequest deleteTransferenceRequest ) {

            var result = await new DeleteTransferenceValidator().ValidateAsync(deleteTransferenceRequest);

            if (result.IsValid) return;
        }
    }
}