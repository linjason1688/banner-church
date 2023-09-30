#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.CreateModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkSignupCommandValidator 
        : AbstractValidator<CreateModActivityWorkSignupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkSignupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWorkSignup, e => e.Name)
            //     );
        }
    }
}
