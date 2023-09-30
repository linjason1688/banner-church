#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.UpdateModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModActivityWorkSignupCommandValidator 
        : AbstractValidator<UpdateModActivityWorkSignupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModActivityWorkSignupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWorkSignup, e => e.Name)
            //     );
        }
    }
}
