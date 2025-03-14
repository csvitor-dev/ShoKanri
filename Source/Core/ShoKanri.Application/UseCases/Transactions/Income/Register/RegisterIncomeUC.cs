using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Register
{
    public class RegisterIncomeUC(
        ITransactionRepository repo,
        IUnitOfWork unitOfWork,
        IMapper mapper

    ) : IRegisterIncomeUC
    {
        public async Task<TransactionResponse> RegisterIncome(RegisterTransactionRequest request)
        {
            await ValidateAsync(request);

            var income = mapper.Map<Domain.Entities.Transactions.Income>(request);

            await repo.CreateAsync(income);

            await unitOfWork.CommitAsync();

            return new TransactionResponse(income.Id, income.Amount, request.Type, DateTime.Now);


        }


        private static async Task ValidateAsync(RegisterTransactionRequest createAccountRequest) {
                
                var result = await new RegisterIncomeValidator().ValidateAsync(createAccountRequest);

                if (result.IsValid)
                return;
            
            }
    }
}