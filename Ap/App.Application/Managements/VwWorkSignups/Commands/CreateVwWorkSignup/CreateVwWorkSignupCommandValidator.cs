#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwWorkSignups.Commands.CreateVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwWorkSignupCommandValidator 
        : AbstractValidator<CreateVwWorkSignupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwWorkSignupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwWorkSignup, e => e.Name)
            //     );
        }
    }
}
