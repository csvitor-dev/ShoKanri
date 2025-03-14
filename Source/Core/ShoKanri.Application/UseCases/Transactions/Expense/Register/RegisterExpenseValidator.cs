using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Register
{
    public class RegisterExpenseValidator: AbstractValidator<RegisterTransactionRequest>
    {
        
        public RegisterExpenseValidator() {

            RuleFor((i) => i.Amount).NotEmpty().NotNull();

        }
    }
}