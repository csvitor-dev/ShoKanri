using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public class GetAllTransferencesUC
    (
        ITransactionReadRepository readRepo,
        IMapper mapper
    ) : IGetAllTransferencesUC
    {
        public async Task<IList<TransactionResponse>> GetAllTransferences(int accountId)
        {
            var transferences = await readRepo.FindAllAsync(accountId);

            Validate(transferences);

            var response = mapper.Map<IList<TransactionResponse>>(transferences);
            return response;
        }

        private static void Validate(IList<Domain.Entities.Transactions.Transaction>? transferences)
        {
            if (transferences?.Any() is false)
                throw new ErrorOnValidationException("nenhuma transferência foi encontrada");
        }
    }
}