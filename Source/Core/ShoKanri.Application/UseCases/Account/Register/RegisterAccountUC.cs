    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoKanri.Domain.Contracts.Data.Repositories.Account;
    using ShoKanri.Domain.Contracts.Data.Repositories.User;
    using ShoKanri.Domain.Contracts.Data.Services;
    using ShoKanri.Http.Requests.Account;
    using ShoKanri.Http.Responses.Account;

    namespace ShoKanri.Application.UseCases.Account.Register
    {
        public class RegisterAccountUC (
            IAccountReadRepository readRepo,
            IAccountWriteRepository writeRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRegisterAccountUC
        {

            public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
            {
                await ValidateAsync(request);

                var account = mapper.Map<Domain.Entities.Account>(request);

                await writeRepo.CreateAsync(account);

                await unitOfWork.CommitAsync();

                return new CreateAccountResponse();  
            }


            private async Task ValidateAsync(CreateAccountRequest createAccountRequest) {
                
                var result = await new RegisterAccountValidator().ValidateAsync(createAccountRequest);

                // var emailExists = await readRepo.ExistsActiveUserWithEmailAsync(request.Email);


                if (result.IsValid)
                return;
                
                var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

                //throw new ErrorOnValidationException(errorMessages);
            }
        }
    }