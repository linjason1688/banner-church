#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Commands.UpdateSysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysSeedIdentityCommandValidator 
        : AbstractValidator<UpdateSysSeedIdentityCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysSeedIdentityCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSeedIdentity, e => e.Name)
            //     );
        }
    }
}
