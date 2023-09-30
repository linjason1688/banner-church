#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Commands.UpdateVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetProfileCommandValidator 
        : AbstractValidator<UpdateVwAspnetProfileCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetProfileCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetProfile, e => e.Name)
            //     );
        }
    }
}
