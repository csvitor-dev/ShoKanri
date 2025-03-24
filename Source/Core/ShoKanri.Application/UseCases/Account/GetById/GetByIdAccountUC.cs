using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Http.Responses.Account;

    namespace ShoKanri.Application.UseCases.Account.GetById
    {
        public class GetByIdAccountUC (
            IAccountReadRepository readRepo,
            IMapper mapper
        ) : IGetByIdAccountUC
        {

            public async Task<GetAccountByIdResponse> GetByIdAccount(int Id, int UserId)
            {

                var account = await readRepo.FindByIdAsync(Id, UserId) ??
                    throw new System.Exception("Account not Found!");
                
                var response = mapper.Map<GetAccountByIdResponse>(account);

                return response;  
            }
        }
    }
