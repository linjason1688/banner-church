#region

using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.PatchRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class PatchRoleUserMappingCommandValidator
        : AbstractValidator<PatchRoleUserMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public PatchRoleUserMappingCommandValidator(IAppDbContext appDbContext)
        {
            //this.RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}
