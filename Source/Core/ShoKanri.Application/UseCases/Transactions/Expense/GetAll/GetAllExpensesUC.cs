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
        public async Task<IList<TransactionResponse>> GetAllExpense(int AccountId)
        {

            var expenses = await readRepo.FindAllAsync(AccountId);
            
            if (expenses == null || !expenses.Any()) throw new System.Exception("sem expenses");

            var response = mapper.Map<IList<TransactionResponse>>(expenses);

            return response;

        }
    }
}