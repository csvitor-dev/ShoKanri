using AutoMapper;
using ShoKanri.Application.UseCases.Account.Register;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

    namespace ShoKanri.Application.UseCases.Account.GetById
    {
        public class GetByIdAccountUC (
            IAccountReadRepository readRepo,
            IAccountWriteRepository writeRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IGetByIdAccountUC
        {

            public async Task<GetByIdAccountResponse> GetByIdAccount(GetByIdAccountRequest request)
            {
                await ValidateAsync(request);

                var account = mapper.Map<Domain.Entities.Account>(request);

                await writeRepo.CreateAsync(account);

                await unitOfWork.CommitAsync();

                return new GetByIdAccountResponse(account.Name, account.UserId, account.Balance, account.Description);  
            }


            private async Task ValidateAsync(GetByIdAccountRequest GetByIdAccountRequest) {
                
                var result = await new GetByIdAccountValidator().ValidateAsync(GetByIdAccountRequest);


                if (result.IsValid)
                return;
                
                var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

            }
        }
    }