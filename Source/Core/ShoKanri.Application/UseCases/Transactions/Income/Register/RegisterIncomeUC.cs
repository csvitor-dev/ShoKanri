using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.Register
{
    public class RegisterIncomeUC
    (
        ITransactionWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : UseCase<RegisterTransactionRequest>(new RegisterIncomeValidator()), IRegisterIncomeUC
    {
        public async Task<TransactionResponse> RegisterIncome(RegisterTransactionRequest request)
        {
            await ValidateAsync(request);

            var income = mapper.Map<Domain.Entities.Transactions.Income>(request);

            await writeRepo.CreateAsync(income);
            await unitOfWork.CommitAsync();

            return new TransactionResponse(income.Id, income.Amount, request.Type, DateTime.Now);
        }
    }
}