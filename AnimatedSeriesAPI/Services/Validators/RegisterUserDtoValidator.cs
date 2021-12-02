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
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password must contain at least 6 caracters")
                .Matches("[A-Z]").WithMessage("Password must contain an upper-case letter")
                .Matches("[a-z]").WithMessage("Password must contain a lower-case letter")
                .Matches("[0-9]").WithMessage("Password must contain at least 1 digit");
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
                        context.AddFailure("Email", "This email address is already registered");
                    }
                });
        }
    }
}