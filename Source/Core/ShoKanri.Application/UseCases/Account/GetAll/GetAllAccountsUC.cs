using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public class GetAllAccountsUC(
        IAccountReadRepository readRepo,
        Mapper mapper

    ) : IGetAllAccountsUC
    {
        public async Task<GetAllAccountsResponse> GetAllAccounts(GetAllAccountsRequest request)
        {
            await ValidateAsync(request);

            var accounts = await readRepo.FindAllAsync(request.UserId);

            if (accounts == null || !accounts.Any()) throw new System.Exception("sem contas");

            var response = mapper.Map<GetAllAccountsResponse>(accounts);

            return response;
        }


        private async Task ValidateAsync(GetAllAccountsRequest getAllAccountRequest) {

            var result =  await new GetAllAccountsValidator().ValidateAsync(getAllAccountRequest);

            if (result.IsValid) return;

            var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

        }

    }
}