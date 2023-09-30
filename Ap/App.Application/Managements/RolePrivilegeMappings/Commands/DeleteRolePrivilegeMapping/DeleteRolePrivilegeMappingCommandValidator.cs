#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.DeleteRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteRolePrivilegeMappingCommandValidator 
        : AbstractValidator<DeleteRolePrivilegeMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteRolePrivilegeMappingCommandValidator()
        {
            //this.RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}
