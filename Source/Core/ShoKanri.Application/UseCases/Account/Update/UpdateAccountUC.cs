using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Update
{
    public class UpdateAccountUC(
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IUpdateAccountUC
    {
        public async Task<UpdateAccountResponse> UpdateAccount(UpdateAccountRequest request)
        {   
            await ValidateAsync(request);

            var account = mapper.Map<Domain.Entities.Account>(request);

            await writeRepo.UpdateAsync(account);
            await unitOfWork.CommitAsync();

            return new UpdateAccountResponse(account.Id, account.Name!, account.Description);
        }

        private static async Task ValidateAsync(UpdateAccountRequest updateAccountRequest)
        {
            var result = await new UpdateAccountValidator().ValidateAsync(updateAccountRequest);


            if (result.IsValid)
                return;

            var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();
                        throw new ValidationException("Validation failed: " + string.Join(", ", errorMessages));
        }
    }
}