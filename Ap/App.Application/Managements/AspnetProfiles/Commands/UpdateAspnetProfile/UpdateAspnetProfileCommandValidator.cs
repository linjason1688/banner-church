#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetProfiles.Commands.UpdateAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetProfileCommandValidator 
        : AbstractValidator<UpdateAspnetProfileCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetProfileCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetProfile, e => e.Name)
            //     );
        }
    }
}
