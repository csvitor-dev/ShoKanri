using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Delete
{
    public class DeleteIncomeUC(
        ITransactionWriteRepository writeRepo,
        ITransactionReadRepository readRepo,
        IUnitOfWork unitOfWork,
        Mapper mapper
    ) : IDeleteIncomeUC
    {
        public async Task<TransactionResponse> DeleteIncome(DeleteTransactionRequest request)
        {
           await ValidateAsync(request);

            await writeRepo.DeleteAsync(request.Id);
            await unitOfWork.CommitAsync();

            var income = await readRepo.FindByIdAsync(request.Id, request.AccountId);
            var response = mapper.Map<TransactionResponse>(income);
            return response;
        }

         private static async Task ValidateAsync(DeleteTransactionRequest deleteTransactionRequest ) {

            var result = await new DeleteIncomeValidator().ValidateAsync(deleteTransactionRequest);

            if (result.IsValid) return;
        }
    }
}