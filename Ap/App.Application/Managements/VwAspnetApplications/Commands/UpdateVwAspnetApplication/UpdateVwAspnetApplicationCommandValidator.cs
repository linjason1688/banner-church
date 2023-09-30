#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Commands.UpdateVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetApplicationCommandValidator 
        : AbstractValidator<UpdateVwAspnetApplicationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetApplicationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetApplication, e => e.Name)
            //     );
        }
    }
}
