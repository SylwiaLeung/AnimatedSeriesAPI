using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Properties;
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
                .NotEmpty().WithMessage(Resources.ResourceManager.GetString("passwordEmpty"))
                .MinimumLength(6).WithMessage(Resources.ResourceManager.GetString("passwordMinCharacters"))
                .Matches("[A-Z]").WithMessage(Resources.ResourceManager.GetString("passwordUpperCase"))
                .Matches("[a-z]").WithMessage(Resources.ResourceManager.GetString("passwordLowerCase"))
                .Matches("[0-9]").WithMessage(Resources.ResourceManager.GetString("passwordMinDigit"));

            RuleFor(x => x)
                .Custom((value, context) =>
                {
                    if (value.Password != value.ConfirmPassword)
                    {
                        context.AddFailure(nameof(value.Password), Resources.ResourceManager.GetString("passwordMatch"));
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (emailUsed)
                    {
                        context.AddFailure("Email", Resources.ResourceManager.GetString("emailTaken"));
                    }
                });
        }
    }
}