using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Exception;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class RegisterAccountValidator : AbstractValidator<RegisterAccountRequest>
    {
        public RegisterAccountValidator()
        {

            RuleFor((a) => a.Name).NotNull().NotEmpty().Length(4, 50);

            RuleFor((a) => a.InitialBalance).NotNull().NotEmpty();

            RuleFor(a => a.Description).MaximumLength(500);
        }
    }
}