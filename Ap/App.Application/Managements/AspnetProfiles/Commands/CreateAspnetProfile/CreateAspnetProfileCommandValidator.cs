#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetProfiles.Commands.CreateAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetProfileCommandValidator 
        : AbstractValidator<CreateAspnetProfileCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetProfileCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetProfile, e => e.Name)
            //     );
        }
    }
}
