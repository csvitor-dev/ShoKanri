using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public interface IRegisterAccountUC
    {
        public Task<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest request);
    }
}