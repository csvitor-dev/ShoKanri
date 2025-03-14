using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Expense.GetAll
{
    public class GetAllExpensesValidator: AbstractValidator<GetAllTransactionRequest>
    {
        public GetAllExpensesValidator() {

            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }
    }
}