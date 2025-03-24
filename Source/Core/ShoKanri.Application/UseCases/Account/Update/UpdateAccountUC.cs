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
    ) : UseCase<UpdateAccountRequest>(new UpdateAccountValidator()), IUpdateAccountUC
    {
        public async Task<UpdateAccountResponse> UpdateAccount(UpdateAccountRequest request)
        {
            await ValidateAsync(request);

            var account = mapper.Map<Domain.Entities.Account>(request);

            await writeRepo.UpdateAsync(account);
            await unitOfWork.CommitAsync();

            return new UpdateAccountResponse(account.Id, account.Name!, account.Description);
        }
    }
}