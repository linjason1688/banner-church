#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPermissions.Commands.DeleteSysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysPermissionCommandValidator 
        : AbstractValidator<DeleteSysPermissionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysPermissionCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
