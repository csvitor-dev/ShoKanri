using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Update
{
    public class UpdateIncomeValidator: AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateIncomeValidator() {
            
            RuleFor((e) => e.Amount).NotEmpty().GreaterThan(0);
            RuleFor((e) => e.Description).NotEmpty();
        }
    }
}