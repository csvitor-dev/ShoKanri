using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public class GetAllAccountsUC : IGetAllAccountsUC
    {
        public Task<GetAllAccountResponse> GetAllAccount(GetAllAccountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}