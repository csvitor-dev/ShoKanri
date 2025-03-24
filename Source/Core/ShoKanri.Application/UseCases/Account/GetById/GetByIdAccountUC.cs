using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetById;

public class GetByIdAccountUC
(
    IAccountReadRepository readRepo,
    IMapper mapper
) : IGetByIdAccountUC
{
    public async Task<GetAccountByIdResponse> GetByIdAccount(int id, int userId)
    {
        var account = await readRepo.FindByIdAsync(id, userId) ??
            throw new ErrorOnValidationException("conta não encontrada");

        var response = mapper.Map<GetAccountByIdResponse>(account);

        return response;
    }
}

