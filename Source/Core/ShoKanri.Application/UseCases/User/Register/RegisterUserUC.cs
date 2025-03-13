using AutoMapper;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.UseCases.User.Register
{
    public class RegisterUserUC (
        IUserReadRepository readRepo,
        IUserWriteRepository writeRepo,
        IUnitOfWork unitOfWork,
        IMapper mapper

    ) : IRegisterUserUC
    {
        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            await ValidateAsync(request);

            var user = mapper.Map<Domain.Entities.User>(request);

            await writeRepo.CreateAsync(user);
            await unitOfWork.CommitAsync();

            

            return new RegisterUserResponse(user.Id, "ewfewwewe"); 
        }


         private static async Task ValidateAsync(RegisterUserRequest registerUserRequest ) {
                
                var result = await new RegisterUserValidator().ValidateAsync(registerUserRequest);

                // var emailExists = await readRepo.ExistsActiveUserWithEmailAsync(request.Email);


                if (result.IsValid)
                return;
                
                var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

                //throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
