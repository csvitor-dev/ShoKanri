using AutoMapper;
using ShoKanri.Application.UseCases.Account.Register;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.Application.UseCases.Account.GetById
{
    public class GetByIdAccountUC(
        IAccountReadRepository readRepo,
        IMapper mapper
    ) : IGetByIdAccountUC
    {

        public async Task<GetByIdAccountResponse> GetByIdAccount(GetByIdAccountRequest request)
        {
            await ValidateAsync(request);

            var account = await readRepo.FindByIdAsync(request.Id, request.UserId);

            var response = mapper.Map<GetByIdAccountResponse>(account);

            return response;
        }


        private async Task ValidateAsync(GetByIdAccountRequest GetByIdAccountRequest)
        {

            var result = await new GetByIdAccountValidator().ValidateAsync(GetByIdAccountRequest);


            if (result.IsValid)
                return;

            var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

        }
    }
}