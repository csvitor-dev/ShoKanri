using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Exception;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class GetByIdAccountValidator : AbstractValidator<GetByIdAccountRequest>
    {
        public GetByIdAccountValidator()
        {

            RuleFor((a) => a.Id).NotNull().NotEmpty();
        }
    }
}