
using FluentValidation;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Update
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator() {

            RuleFor((u) => u.Id).NotEmpty().NotNull();

            RuleFor((u) => u.Name).NotEmpty().NotNull();

            RuleFor((u) => u.Email).NotNull().NotEmpty().EmailAddress();

            RuleFor((u) => u.Password).NotEmpty().NotNull();

        }
    }
}