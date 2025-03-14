using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Update
{
    public class UpdateExpenseValidator: AbstractValidator<UpdateTransactionRequest>
    {
        public UpdateExpenseValidator() {
            
            RuleFor((e) => e.Id).NotEmpty().NotNull();

            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }
    }
}