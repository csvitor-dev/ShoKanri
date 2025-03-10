    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Contracts.Data.Services;
    using ShoKanri.Http.Requests.Transaction;
    using ShoKanri.Http.Responses.Transaction;

    namespace ShoKanri.Application.UseCases.Expense.Register
    {
        public class RegisterExpenseUc(
            ITransactionRepository repo,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRegisterExpenseUC
        {
            public  async Task<TransactionResponse> RegisterExpense(RegisterTransactionRequest request)
            {
                await ValidateAsync(request);

                var expense = mapper.Map<Domain.Entities.Transactions.Expense>(request);

                await repo.CreateAsync(expense);

                await unitOfWork.CommitAsync();

                return new TransactionResponse(expense.Id, expense.Amount, request.Type, DateTime.Now);
            }

            private static async Task ValidateAsync(RegisterTransactionRequest createExpenseRequest) {
                    
                    var result = await new RegisterExpenseValidator().ValidateAsync(createExpenseRequest);

                    if (result.IsValid)
                    return;
                
                }
        }
    }