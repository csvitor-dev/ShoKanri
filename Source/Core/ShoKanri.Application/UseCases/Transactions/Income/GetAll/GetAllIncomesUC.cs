using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.GetAll
{
    public class GetAllIncomesUC(
        ITransactionReadRepository readRepo,
        IMapper mapper
    ) : IGetAllIncomesUC
    {
        public async Task<IList<TransactionResponse>> GetAllExpense(int accountId)
        {

            var incomes = await readRepo.FindAllAsync(accountId);

            Validate(incomes);

            var response = mapper.Map<IList<TransactionResponse>>(incomes);
            return response;
        }
        private static void Validate(IList<Domain.Entities.Transactions.Transaction>? incomes)
        {
            if (incomes?.Any() is false)
                throw new ErrorOnValidationException("nenhuma receita foi encontrada");
        }
    }
}