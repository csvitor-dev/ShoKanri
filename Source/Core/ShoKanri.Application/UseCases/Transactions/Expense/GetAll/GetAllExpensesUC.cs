using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.GetAll
{
    public class GetAllExpensesUC(
        ITransactionReadRepository readRepo,
        IMapper mapper

    ) : IGetAllExpensesUC
    {
        public async Task<IList<TransactionResponse>> GetAllExpense(int accountId)
        {

            var expenses = await readRepo.FindAllAsync(accountId);

            Validate(expenses);

            var response = mapper.Map<IList<TransactionResponse>>(expenses);

            return response;
        }

        private static void Validate(IList<Domain.Entities.Transactions.Transaction>? expenses)
        {
            if (expenses?.Any() is false)
                throw new ErrorOnValidationException("nenhuma despesa foi encontrada");
        }
    }
}