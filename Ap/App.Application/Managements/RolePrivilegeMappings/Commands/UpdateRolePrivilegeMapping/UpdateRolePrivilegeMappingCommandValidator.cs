#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.UpdateRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateRolePrivilegeMappingCommandValidator 
        : AbstractValidator<UpdateRolePrivilegeMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateRolePrivilegeMappingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.RolePrivilegeMapping, e => e.Name)
            //     );
        }
    }
}
