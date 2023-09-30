using FluentValidation;

namespace App.Application.Features.ResetPassword
{
    /// <summary>
    /// </summary>
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
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
