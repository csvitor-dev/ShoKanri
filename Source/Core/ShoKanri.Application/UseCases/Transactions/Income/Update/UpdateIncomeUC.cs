using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Update
{
    public class UpdateIncomeUC(
        ITransactionWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        Mapper mapper
    ) : IUpdateIncomeUC
    {
        public async Task<TransactionResponse> UpdateExpense(UpdateTransactionRequest request)
        {
            await ValidateAsync(request);

             var expense = mapper.Map<Domain.Entities.Transactions.Expense>(request);

             await writeRepo.UpdateAsync(expense);
             await unitOfWork.CommitAsync();

             var response =  mapper.Map<TransactionResponse>(expense);

             return response;
        }



         private static async Task ValidateAsync(UpdateTransactionRequest updateTransactionRequest ) {

            var result = await new UpdateIncomeValidator().ValidateAsync(updateTransactionRequest);

            if (result.IsValid) return;
        }
    }
}