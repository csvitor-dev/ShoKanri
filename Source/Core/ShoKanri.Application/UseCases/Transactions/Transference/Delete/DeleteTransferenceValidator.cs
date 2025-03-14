using FluentValidation;
using ShoKanri.Http.Requests.Transaction.Transference;

namespace ShoKanri.Application.UseCases.Transactions.Transference.Delete
{
    public class DeleteTransferenceValidator: AbstractValidator<DeleteTransferenceRequest>
    {
        public DeleteTransferenceValidator() {

            RuleFor((t) => t.Id).NotEmpty().NotNull();

            RuleFor((t) => t.AccountId).NotEmpty().NotNull();
        }   
    }
}