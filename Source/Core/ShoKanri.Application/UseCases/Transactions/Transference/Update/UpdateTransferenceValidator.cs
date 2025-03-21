using FluentValidation;
using ShoKanri.Http.Requests.Transaction.Transference;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Update
{
    public class UpdateTransferenceValidator: AbstractValidator<UpdateTransferenceRequest>
    {
        public UpdateTransferenceValidator() {

            RuleFor((e) => e.Amount).NotEmpty().GreaterThan(0);
            RuleFor((e) => e.Description).NotEmpty();
        }   
    }
}