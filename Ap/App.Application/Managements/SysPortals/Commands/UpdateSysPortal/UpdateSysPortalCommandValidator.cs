#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPortals.Commands.UpdateSysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysPortalCommandValidator 
        : AbstractValidator<UpdateSysPortalCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysPortalCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysPortal, e => e.Name)
            //     );
        }
    }
}
