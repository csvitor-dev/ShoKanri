using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Delete
{
    public class DeleteAccountUC(
        IAccountReadRepository readRepo,
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IDeleteAccountUC
    {
        public async Task<DeleteAccountResponse> DeleteAccount(DeleteAccountRequest request)
        {
            await ValidateAsync(request);

            var account = mapper.Map<Domain.Entities.Account>(request);

            await writeRepo.DeleteAsync(request.Id);
            await unitOfWork.CommitAsync();

            return new DeleteAccountResponse(account.Id, account.Name);
        }

        private async Task ValidateAsync(DeleteAccountRequest deleteAccountRequest) {

            var result = await new DeleteAccountValidator().ValidateAsync(deleteAccountRequest);


            if (result.IsValid)
                return;
                
                var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

        }

    }
}