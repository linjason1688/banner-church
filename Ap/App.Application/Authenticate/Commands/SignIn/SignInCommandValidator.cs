#region

using FluentValidation;

#endregion

namespace App.Application.Authenticate.Commands.SignIn
{
    /// <summary>
    /// </summary>
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            this.RuleFor(r => r.Account)
               .NotEmpty();

            this.RuleFor(r => r.Password)
               .NotEmpty();

            this.RuleFor(r => r.VerificationCode)
               .NotEmpty();

            this.RuleFor(r => r.VerificationToken)
               .NotEmpty();
            
            // example for validate length from schema config
            // this.RuleFor(r => r.AppVersion)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AppExecutionLog, e => e.AppVersion)
            //     );
        }
    }
}
