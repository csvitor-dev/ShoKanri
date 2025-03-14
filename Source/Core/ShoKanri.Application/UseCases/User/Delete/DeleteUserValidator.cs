
using FluentValidation;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Delete
{
    public class DeleteUserValidator: AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator() {

            RuleFor((u) => u.Id).NotEmpty().NotNull();

        }   
    }
}