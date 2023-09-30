#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysPortals.Commands.CreateSysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysPortalCommandValidator 
        : AbstractValidator<CreateSysPortalCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysPortalCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysPortal, e => e.Name)
            //     );
        }
    }
}
