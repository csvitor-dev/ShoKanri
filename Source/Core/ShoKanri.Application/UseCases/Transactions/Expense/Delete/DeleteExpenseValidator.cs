using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.Delete
{
    public class DeleteExpenseValidator: AbstractValidator<DeleteTransactionRequest>
    {
        public DeleteExpenseValidator() {

            RuleFor((e) => e.Id).NotEmpty().NotNull();
            
            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }
    }
}