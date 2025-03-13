using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Update
{
    public class UpdateUserUC (
        IUserReadRepository readRepo,
        IUserWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper
        
    ): IUpdateUserUC
    {
        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            await ValidateAsync(request);

            var UpdateUser = mapper.Map<Domain.Entities.User>(request);

            await writeRepo.UpdateAsync(UpdateUser);
            await unitOfWork.CommitAsync();

            return new UpdateUserResponse(UpdateUser.Id, UpdateUser.Name, UpdateUser.Email);
        }

        private static async Task ValidateAsync(UpdateUserRequest updateUserRequest ) {

            var result = await new UpdateUserValidator().ValidateAsync(updateUserRequest);

            if (result.IsValid) return;

        }

    }
}