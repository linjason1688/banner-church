using FluentValidation;

namespace App.Application.Features.FindAccount
{
    /// <summary>
    /// </summary>
    public class FindAccountCommandValidator : AbstractValidator<FindAccountCommand>
    {
        public FindAccountCommandValidator()
        {
            this.RuleFor(m => m.Email)
               .NotEmpty()
               .When(m => string.IsNullOrEmpty(m.MobileNo));

            this.RuleFor(m => m.MobileNo)
               .NotEmpty()
               .When(m => string.IsNullOrEmpty(m.Email));
        }
    }
}
