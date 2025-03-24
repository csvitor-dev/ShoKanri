
using FluentValidation;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Update
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor((u) => u.Name).NotEmpty().Length(4, 50)
                .When((u) => u.Name is not null);

            RuleFor((u) => u.Email).NotEmpty().EmailAddress()
                .When((u) => u.Email is not null);
        }
    }
}