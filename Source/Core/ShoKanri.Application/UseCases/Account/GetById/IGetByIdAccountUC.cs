using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetById
{
    public interface IGetByIdAccountUC
    {
        public Task<GetAccountByIdResponse> GetByIdAccount(int Id, int UserId);
    }
}