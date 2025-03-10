using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Register
{
    public class RegisterIncomeValidator:  AbstractValidator<RegisterTransactionRequest>
    {
        
        public RegisterIncomeValidator() {

            RuleFor((i) => i.Amount).NotEmpty().NotNull();

        }
    }
}