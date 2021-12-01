using AnimatedSeriesAPI.Data;
using FluentValidation;
using System.Linq;

namespace AnimatedSeriesAPI.Models
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        [System.Obsolete]
        public RegisterUserDtoValidator(SeriesDbContext dbContext)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x)
                .Custom((value, context) =>
                {
                    if (value.Password != value.ConfirmPassword)
                    {
                        context.AddFailure(nameof(value.Password), "Passwords should match");
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailUsed = dbContext.Users.Any(u => u.Email == value);
                    if (emailUsed)
                    {
                        context.AddFailure("Email", "This email address is already registered.");
                    }
                });
        }
    }
}