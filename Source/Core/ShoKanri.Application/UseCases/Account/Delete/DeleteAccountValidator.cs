using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public class DeleteAccountValidator: AbstractValidator<DeleteAccountRequest>
    {
        public DeleteAccountValidator() {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
    }
