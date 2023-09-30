using FluentValidation;

namespace App.Application.Features.UPastoral
{//#CreateAPI
    /// <summary>
    /// </summary>
    public class UPastoralCommandValidator : AbstractValidator<UPastoralCommand>
    {
        public UPastoralCommandValidator()
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
