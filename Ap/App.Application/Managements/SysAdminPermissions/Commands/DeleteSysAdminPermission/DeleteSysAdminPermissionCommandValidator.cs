#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysAdminPermissions.Commands.DeleteSysAdminPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysAdminPermissionCommandValidator 
        : AbstractValidator<DeleteSysAdminPermissionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysAdminPermissionCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
