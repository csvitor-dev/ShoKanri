using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Update
{
    public class UpdateExpenseUC(
        ITransactionWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper

    ) : UseCase<UpdateTransactionRequest>(new UpdateExpenseValidator()), IUpdateExpenseUC
    {
        public async Task<TransactionResponse> UpdateExpense(UpdateTransactionRequest request)
        {
            await ValidateAsync(request);

            var expense = mapper.Map<Domain.Entities.Transactions.Expense>(request);

            await writeRepo.UpdateAsync(expense);
            await unitOfWork.CommitAsync();

            var response = mapper.Map<TransactionResponse>(expense);

            return response;
        }
    }
}