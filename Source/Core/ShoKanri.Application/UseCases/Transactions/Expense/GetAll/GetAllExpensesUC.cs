using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.GetAll
{
    public class GetAllExpensesUC(
        ITransactionReadRepository readRepo,
        IMapper mapper

    ) : IGetAllExpensesUC
    {
        public async Task<TransactionResponse> GetAllExpense(GetAllTransactionRequest request)
        {
            await ValidateAsync(request);

            var expenses = await readRepo.FindAllAsync(request.AccountId);
            
            if (expenses == null || !expenses.Any()) throw new System.Exception("sem expenses");

            var response = mapper.Map<TransactionResponse>(expenses);

            return response;

        }

        private static async Task ValidateAsync(GetAllTransactionRequest getAllTransactionRequest ) {

            var result = await new GetAllExpensesValidator().ValidateAsync(getAllTransactionRequest);

            if (result.IsValid) return;
        }
    }
}