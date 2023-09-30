#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPermissions.Commands.UpdateSysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysPermissionCommandValidator 
        : AbstractValidator<UpdateSysPermissionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysPermissionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysPermission, e => e.Name)
            //     );
        }
    }
}
