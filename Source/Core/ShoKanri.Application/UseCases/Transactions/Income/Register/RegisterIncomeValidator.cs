using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Register
{
    public class RegisterIncomeValidator:  AbstractValidator<RegisterTransactionRequest>
    {
        
        public RegisterIncomeValidator() {

            RuleFor((i) => i.Amount).NotEmpty().NotNull();

        }
    }
}