using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public class GetAllAccountsUC(
        IAccountReadRepository readRepo,
        IMapper mapper

    ) : IGetAllAccountsUC
    {
        public async Task<IList<GetAllAccountsResponse>> GetAllAccounts(int UserId)
        {

            var accounts = await readRepo.FindAllAsync(UserId);

            if (accounts == null || !accounts.Any()) throw new System.Exception("sem contas");

            var response = mapper.Map<IList<GetAllAccountsResponse>>(accounts);

            return response;
        }

    }
}