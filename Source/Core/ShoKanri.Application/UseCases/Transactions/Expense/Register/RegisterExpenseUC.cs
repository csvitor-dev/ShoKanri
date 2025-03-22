using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
    using ShoKanri.Http.Requests.Transaction;
    using ShoKanri.Http.Responses.Transaction;

    namespace ShoKanri.Application.UseCases.Transactions.Expense.Register
    {
        public class RegisterExpenseUC(
            ITransactionWriteRepository writeRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRegisterExpenseUC
        {
            public  async Task<TransactionResponse> RegisterExpense(RegisterTransactionRequest request)
            {
                await ValidateAsync(request);

                var expense = mapper.Map<Domain.Entities.Transactions.Expense>(request);

                await writeRepo.CreateAsync(expense);

                await unitOfWork.CommitAsync();

                return new TransactionResponse(expense.Id, expense.Amount, request.Type, DateTime.Now);
            }

            private static async Task ValidateAsync(RegisterTransactionRequest createExpenseRequest) {
                    
                    var result = await new RegisterExpenseValidator().ValidateAsync(createExpenseRequest);

                    if (!result.IsValid){
                        var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                            throw new System.Exception(string.Join("; ", errorMessages));
                    }
                    return;
                
                }
        }
    }