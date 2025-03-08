using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Register
{
    public interface IRegisterUserUC
    {
        public Task Execute(CreateUserRequest request);
    }
}