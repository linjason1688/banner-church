#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.CreateRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateRolePrivilegeMappingCommandValidator 
        : AbstractValidator<CreateRolePrivilegeMappingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateRolePrivilegeMappingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.RolePrivilegeMapping, e => e.Name)
            //     );
        }
    }
}
