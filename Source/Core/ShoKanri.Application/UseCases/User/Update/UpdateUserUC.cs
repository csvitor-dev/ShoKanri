using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Exception.Project;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Update;

public class UpdateUserUC
(
    IUserWriteRepository writeRepo,
    IUserReadRepository readRepo,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : UseCase<UpdateUserRequest>(new UpdateUserValidator()), IUpdateUserUC
{
    public async Task<UpdateUserResponse> UpdateUser(int id, UpdateUserRequest request)
    {
        await ValidateAsync(request);

        var user = await readRepo.FindByIdAsync(id)
            ?? throw new NotFoundException("usuário com o id {id} não foi encontrado");

        var mapUser = mapper.Map(request, user);
        mapUser.UpdatedOn = DateTimeOffset.Now.UtcDateTime;

        await writeRepo.UpdateAsync(mapUser);
        await unitOfWork.CommitAsync();

        return new UpdateUserResponse(mapUser.Id, mapUser.Name!, mapUser.Email!);
    }
}