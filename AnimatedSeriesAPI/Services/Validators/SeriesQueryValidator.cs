using AnimatedSeriesAPI.Models;
using FluentValidation;
using System.Linq;

namespace AnimatedSeriesAPI.Services
{
    public class SongsQueryValidator : AbstractValidator<SeriesQuery>
    {
        private int[] allowedPageSizes = new[] { 1, 3, 5 };
        public SongsQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
        }
    }
}
