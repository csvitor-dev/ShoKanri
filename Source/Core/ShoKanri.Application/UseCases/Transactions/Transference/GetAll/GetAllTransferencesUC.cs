using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public class GetAllTransferencesUC (
        ITransactionReadRepository readRepo,
        IMapper mapper

    ): IGetAllTransferencesUC
    {
        public async Task<IList<TransactionResponse>> GetAllTransferences(int Id, int AccountId)
        {

            var transferences = await readRepo.FindAllAsync(AccountId);

            if (transferences == null || !transferences.Any()) throw new System.Exception("sem Transferences");

            var response = mapper.Map<IList<TransactionResponse>>(transferences);

            return response;

        }

    }
}