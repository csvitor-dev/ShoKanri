    using AutoMapper;
    using ShoKanri.Domain.Contracts.Data.Repositories;
    using ShoKanri.Domain.Contracts.Data.Services;
    using ShoKanri.Http.Requests.Account;
    using ShoKanri.Http.Responses.Account;

    namespace ShoKanri.Application.UseCases.Account.Register
    {
        public class RegisterAccountUC (
            IAccountRepository repo,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRegisterAccountUC
        {

            public async Task<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest request)
            {
                await ValidateAsync(request);

                var account = mapper.Map<Domain.Entities.Account>(request);

                await repo.CreateAsync(account);

                await unitOfWork.CommitAsync();

                return new RegisterAccountResponse(request.UserId, account.Name);  
            }


            private async Task ValidateAsync(RegisterAccountRequest createAccountRequest) {
                
                var result = await new RegisterAccountValidator().ValidateAsync(createAccountRequest);


                if (result.IsValid)
                return;
                
                var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

            }
        }
    }