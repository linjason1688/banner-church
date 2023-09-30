using FluentValidation;

namespace App.Application.Features.SignUp
{
    /// <summary>
    /// </summary>
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
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
