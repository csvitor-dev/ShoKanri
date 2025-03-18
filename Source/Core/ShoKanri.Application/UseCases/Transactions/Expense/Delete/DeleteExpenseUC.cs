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
        public async Task<TransactionResponse> DeleteExpense(DeleteTransactionRequest request)
        {
            await ValidateAsync(request);

            await writeRepo.DeleteAsync(request.Id);
            await unitOfWork.CommitAsync();

            var expense = await readRepo.FindByIdAsync(request.Id, request.AccountId);
            var response = mapper.Map<TransactionResponse>(expense);
            return response;



        }

        private static async Task ValidateAsync(DeleteTransactionRequest deleteTransactionRequest ) {

            var result = await new DeleteExpenseValidator().ValidateAsync(deleteTransactionRequest);

            if (result.IsValid) return;
        }

    }
}