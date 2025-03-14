using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Update
{
    public class UpdateIncomeValidator: AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateIncomeValidator() {
            
            RuleFor((e) => e.Id).NotEmpty().NotNull();

            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }
    }
}