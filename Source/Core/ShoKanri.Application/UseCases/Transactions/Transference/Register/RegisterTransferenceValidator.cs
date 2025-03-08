using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transference.Register
{
    public class RegisterTransferenceValidator: AbstractValidator<CreateTransactionRequest>
    {
        RegisterTransferenceValidator() {
            RuleFor(request => request.Amount)
                .NotEmpty().GreaterThan(0);

            RuleFor(request => request.Description)
                .MaximumLength(500);
        }
    }
}