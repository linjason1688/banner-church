#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysPermissions.Commands.CreateSysPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysPermissionCommandValidator 
        : AbstractValidator<CreateSysPermissionCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysPermissionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysPermission, e => e.Name)
            //     );
        }
    }
}
