#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysAdminPermissions.Commands.CreateSysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysAdminPermissionCommandValidator 
        : AbstractValidator<CreateSysAdminPermissionCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysAdminPermissionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysAdminPermission, e => e.Name)
            //     );
        }
    }
}
