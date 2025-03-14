using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public class GetAllTransferencesUC (
        ITransactionReadRepository readRepo,
        Mapper mapper

    ): IGetAllTransferencesUC
    {
        public async Task<TransactionResponse> GetAllTransferences(GetAllTransferencesRequest request)
        {
            await ValidateAsync(request);

            var transferences = await readRepo.FindAllAsync(request.AccountId);

            if (transferences == null || !transferences.Any()) throw new System.Exception("sem Transferences");

            var response = mapper.Map<TransactionResponse>(transferences);

            return response;

        }


        private static async Task ValidateAsync(GetAllTransferencesRequest getAllTransferencesRequest ) {

            var result = await new GetAllTransferencesValidator().ValidateAsync(getAllTransferencesRequest);

            if (result.IsValid) return;
        }
    }
}