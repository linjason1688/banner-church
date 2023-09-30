using FluentValidation;

namespace App.Application.Features.UMinistry
{
    /// <summary>
    /// </summary>
    public class UMinistryCommandValidator : AbstractValidator<UMinistryCommand>
    {
        public UMinistryCommandValidator()
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
