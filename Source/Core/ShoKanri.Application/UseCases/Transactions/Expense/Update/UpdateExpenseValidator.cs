using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Update
{
    public class UpdateExpenseValidator: AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateExpenseValidator() {
            
            RuleFor((e) => e.Amount).NotEmpty().GreaterThan(0);
            RuleFor((e) => e.Description).NotEmpty();

        }
    }
}