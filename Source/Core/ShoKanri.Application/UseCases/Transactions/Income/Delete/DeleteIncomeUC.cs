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
        public async Task<TransactionResponse> DeleteIncome(int Id, int AccountId)
        {

            await writeRepo.DeleteAsync(Id);
            await unitOfWork.CommitAsync();

            var income = await readRepo.FindByIdAsync(Id, AccountId);
            var response = mapper.Map<TransactionResponse>(income);
            return response;
        }
    }
}