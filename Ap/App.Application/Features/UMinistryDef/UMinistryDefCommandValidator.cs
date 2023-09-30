using FluentValidation;

namespace App.Application.Features.UMinistryDef
{//#CreateAPI
    /// <summary>
    /// </summary>
    public class UMinistryDefCommandValidator : AbstractValidator<UMinistryDefCommand>
    {
        public UMinistryDefCommandValidator()
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
