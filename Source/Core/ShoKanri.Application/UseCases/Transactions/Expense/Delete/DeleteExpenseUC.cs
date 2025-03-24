using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Delete
{
    public class DeleteExpenseUC(
        ITransactionWriteRepository writeRepo,
        ITransactionReadRepository readRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper

    ) : IDeleteExpenseUC
    {
        public async Task<TransactionResponse> DeleteExpense(int id, int accountId)
        {
            await writeRepo.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            var expense = await readRepo.FindByIdAsync(id, accountId);
            var response = mapper.Map<TransactionResponse>(expense);
    
            return response;
        }
    }
}