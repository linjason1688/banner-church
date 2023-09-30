using FluentValidation;

namespace App.Application.Features.SendVerificationCode
{
    /// <summary>
    /// </summary>
    public class SendVerificationCodeRequestValidator : AbstractValidator<SendVerificationCodeRequest>
    {
        public SendVerificationCodeRequestValidator()
        {
            RuleFor(m => m.Account).NotEmpty();
        }
    }
}
