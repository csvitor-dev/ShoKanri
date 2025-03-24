using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public interface IGetAllAccountsUC
    {
        public Task<IList<GetAllAccountsResponse>> GetAllAccounts(int userId);
    }
}