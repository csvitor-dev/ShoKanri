using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public interface IGetAllAccountsUC
    {
        public Task<GetAllAccountResponse> GetAllAccount(GetAllAccountRequest request);

    }
}