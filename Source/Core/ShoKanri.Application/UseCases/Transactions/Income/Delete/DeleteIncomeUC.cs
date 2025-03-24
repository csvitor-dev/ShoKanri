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
        IMapper mapper
    ) : IDeleteIncomeUC
    {
        public async Task<TransactionResponse> DeleteIncome(int id, int accountId)
        {

            await writeRepo.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            var income = await readRepo.FindByIdAsync(id, accountId);
            var response = mapper.Map<TransactionResponse>(income);
            return response;
        }
    }
}