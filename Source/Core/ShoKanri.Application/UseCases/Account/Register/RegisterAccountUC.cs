using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class RegisterAccountUC
    (
        IUserReadRepository userReadRepo,
        IAccountWriteRepository accountWriteRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : UseCase<RegisterAccountRequest>(new RegisterAccountValidator()), IRegisterAccountUC
    {
        public async Task<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest request)
        {
            await ValidateAsync(request);

            var account = mapper.Map<Domain.Entities.Account>(request);

            await accountWriteRepo.CreateAsync(account);
            await unitOfWork.CommitAsync();

            return new RegisterAccountResponse(account.Id, account.Name!);
        }

        protected override async Task<string> ApplyExtraValidationAsync(RegisterAccountRequest request)
        {
            var user = await userReadRepo.FindByIdAsync(request.UserId);

            return user is null
                ? $"não existe um usuário com o id {request.UserId}"
                : string.Empty;
        }
    }
}