using FluentValidation;
using ShoKanri.Http.Requests.Transaction.Transference;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Register
{
    public class RegisterTransferenceValidator: AbstractValidator<RegisterTransferenceRequest>
    {
        public RegisterTransferenceValidator() {
            RuleFor(request => request.Amount)
                .NotEmpty().GreaterThan(0);

            RuleFor(request => request.Description)
                .MaximumLength(500);
        }
    }
}