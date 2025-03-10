using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Expense.Register
{
    public class RegisterExpenseValidator: AbstractValidator<RegisterTransactionRequest>
    {
        
        public RegisterExpenseValidator() {

            RuleFor((i) => i.Amount).NotEmpty().NotNull();

        }
    }
}