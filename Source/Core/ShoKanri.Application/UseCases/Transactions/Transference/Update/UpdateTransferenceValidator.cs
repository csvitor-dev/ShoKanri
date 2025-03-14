using FluentValidation;
using ShoKanri.Http.Requests.Transaction.Transference;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Update
{
    public class UpdateTransferenceValidator: AbstractValidator<UpdateTransferenceRequest>
    {
        public UpdateTransferenceValidator() {

            RuleFor((e) => e.Id).NotEmpty().NotNull();

            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }   
    }
}