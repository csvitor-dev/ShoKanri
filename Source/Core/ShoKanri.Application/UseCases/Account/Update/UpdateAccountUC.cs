using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Update
{
    public class UpdateAccountUC(
        IAccountReadRepository readRepo,
        IAccountWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : UseCase<UpdateAccountRequest>(new UpdateAccountValidator()), IUpdateAccountUC
    {
        public async Task<UpdateAccountResponse> UpdateAccount(int userId, int id, UpdateAccountRequest request)
        {
            await ValidateAsync(request);

            var account = await readRepo.FindByIdAsync(userId, id)
                ?? throw new NotFoundException($"usuário com o id {userId} ou conta com o id {id} não foram encontrados");

            var mapAccount = mapper.Map(request, account);
            mapAccount.UpdatedOn = DateTimeOffset.Now.UtcDateTime;

            await writeRepo.UpdateAsync(mapAccount);
            await unitOfWork.CommitAsync();

            return new UpdateAccountResponse(account.Id, account.Name!, account.Description);
        }
    }
}