using FluentValidation;

namespace App.Application.Features.ChildSignUp
{
    /// <summary>
    /// </summary>
    public class ChildSignUpCommandValidator : AbstractValidator<ChildSignUpCommand>
    {
        public ChildSignUpCommandValidator()
        {
            // RuleFor(m => m.Email)
            //    .NotEmpty()
            //    .When(m => string.IsNullOrEmpty(m.MobileNo));
            //
            // RuleFor(m => m.MobileNo)
            //    .NotEmpty()
            //    .When(m => string.IsNullOrEmpty(m.Email));
        }
    }
}
