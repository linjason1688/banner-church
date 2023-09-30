#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwWorkSignups.Commands.UpdateVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwWorkSignupCommandValidator 
        : AbstractValidator<UpdateVwWorkSignupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwWorkSignupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwWorkSignup, e => e.Name)
            //     );
        }
    }
}
