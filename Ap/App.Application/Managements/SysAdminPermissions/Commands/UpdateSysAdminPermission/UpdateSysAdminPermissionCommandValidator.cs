#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Commands.UpdateSysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysAdminPermissionCommandValidator 
        : AbstractValidator<UpdateSysAdminPermissionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysAdminPermissionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysAdminPermission, e => e.Name)
            //     );
        }
    }
}
