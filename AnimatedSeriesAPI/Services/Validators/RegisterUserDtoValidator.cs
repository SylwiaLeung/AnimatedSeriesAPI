using AnimatedSeriesAPI.Data;
using FluentValidation;
using System.Linq;

namespace AnimatedSeriesAPI.Models
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        [System.Obsolete]
        public RegisterUserDtoValidator(SeriesDbContext dbContext, ResourceManagerService resourceManager)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(resourceManager.Manager.GetString("passwordEmpty"))
                .MinimumLength(6).WithMessage(resourceManager.Manager.GetString("passwordMinCharacters"))
                .Matches("[A-Z]").WithMessage(resourceManager.Manager.GetString("passwordUpperCase"))
                .Matches("[a-z]").WithMessage(resourceManager.Manager.GetString("passwordLowerCase"))
                .Matches("[0-9]").WithMessage(resourceManager.Manager.GetString("passwordMinDigit"));
            RuleFor(x => x)
                .Custom((value, context) =>
                {
                    if (value.Password != value.ConfirmPassword)
                    {
                        context.AddFailure(nameof(value.Password), resourceManager.Manager.GetString("passwordMatch"));
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (emailUsed)
                    {
                        context.AddFailure("Email", resourceManager.Manager.GetString("emailTaken"));
                    }
                });
        }
    }
}