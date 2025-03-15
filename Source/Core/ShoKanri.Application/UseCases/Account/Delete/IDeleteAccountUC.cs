using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public interface IDeleteAccountUC
    {
        public Task<DeleteAccountResponse> DeleteAccount(DeleteAccountRequest request);
    }
}