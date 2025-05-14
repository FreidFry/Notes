using FluentValidation;
using Notes.Server.Features.Auth.Registration.Services;

namespace Notes.Server.Features.Auth.Registration.Validations
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
        }
    }
}
