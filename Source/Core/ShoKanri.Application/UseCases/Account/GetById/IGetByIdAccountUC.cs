using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetById
{
    public interface IGetByIdAccountUC
    {
        public Task<GetByIdAccountResponse> GetByIdAccount(GetByIdAccountRequest request);
    }
}