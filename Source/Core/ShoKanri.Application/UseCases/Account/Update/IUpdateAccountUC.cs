using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Update
{
    public interface IUpdateAccountUC
    {
        public Task<UpdateAccountResponse> UpdateAccount(UpdateAccountRequest request);

    }
}