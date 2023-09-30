#region

using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.RolePrivilegeMappings.Commands.PatchRolePrivilegeMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class PatchRolePrivilegeMappingCommandValidator
        : AbstractValidator<PatchRolePrivilegeMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public PatchRolePrivilegeMappingCommandValidator(IAppDbContext appDbContext)
        {
            //this.RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}
