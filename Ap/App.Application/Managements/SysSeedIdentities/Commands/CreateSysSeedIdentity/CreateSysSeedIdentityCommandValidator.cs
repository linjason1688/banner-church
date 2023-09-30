#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysSeedIdentities.Commands.CreateSysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSeedIdentityCommandValidator 
        : AbstractValidator<CreateSysSeedIdentityCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysSeedIdentityCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSeedIdentity, e => e.Name)
            //     );
        }
    }
}
