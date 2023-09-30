#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetProfiles.Commands.CreateVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetProfileCommandValidator 
        : AbstractValidator<CreateVwAspnetProfileCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetProfileCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetProfile, e => e.Name)
            //     );
        }
    }
}
