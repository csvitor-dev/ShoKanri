using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll;

public class GetAllAccountsUC
(
    IAccountReadRepository readRepo,
    IMapper mapper
) : IGetAllAccountsUC
{
    public async Task<IList<GetAllAccountsResponse>> GetAllAccounts(int userId)
    {
        var accounts = await readRepo.FindAllAsync(userId);

        Validate(accounts);

        var response = mapper.Map<List<GetAllAccountsResponse>>(accounts);
        return response;
    }

    private static void Validate(IList<Domain.Entities.Account>? accounts)
    {
        if (accounts?.Any() is false)
            throw new NotFoundException("nenhuma conta foi encontrada");
    }
}