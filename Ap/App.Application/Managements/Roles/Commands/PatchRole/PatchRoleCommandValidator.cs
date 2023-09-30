#region

using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Commands.PatchRole
{
    /// <summary>
    /// 
    /// </summary>
    public class PatchRoleMappingCommandValidator
        : AbstractValidator<PatchRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public PatchRoleMappingCommandValidator(IAppDbContext appDbContext)
        {
            //this.RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}
