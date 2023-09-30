using FluentValidation;

namespace App.Application.Features.UpdatePassword
{
    /// <summary>
    /// </summary>
    public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(m => m.Password)
               .NotEmpty()
               .When(m => string.IsNullOrEmpty(m.Password));
        }
    }
}
