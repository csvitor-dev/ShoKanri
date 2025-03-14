using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Delete
{
    public class DeleteIncomeValidator: AbstractValidator<DeleteTransactionRequest>
    {
        public DeleteIncomeValidator(){
            
            RuleFor((e) => e.Id).NotEmpty().NotNull();
            
            RuleFor((e) => e.AccountId).NotEmpty().NotNull();
        }
    }
}