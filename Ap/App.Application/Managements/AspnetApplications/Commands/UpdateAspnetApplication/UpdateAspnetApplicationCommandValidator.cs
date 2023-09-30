#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetApplications.Commands.UpdateAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetApplicationCommandValidator 
        : AbstractValidator<UpdateAspnetApplicationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetApplicationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetApplication, e => e.Name)
            //     );
        }
    }
}
