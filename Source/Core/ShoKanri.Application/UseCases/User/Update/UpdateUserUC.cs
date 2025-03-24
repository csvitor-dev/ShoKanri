using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Update;

public class UpdateUserUC
(
    IUserWriteRepository writeRepo,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : UseCase<UpdateUserRequest>(new UpdateUserValidator()), IUpdateUserUC
{
    public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
    {
        await ValidateAsync(request);

        var user = mapper.Map<Domain.Entities.User>(request);

        await writeRepo.UpdateAsync(user);
        await unitOfWork.CommitAsync();

        return new UpdateUserResponse(user.Id, user.Name!, user.Email!);
    }
}