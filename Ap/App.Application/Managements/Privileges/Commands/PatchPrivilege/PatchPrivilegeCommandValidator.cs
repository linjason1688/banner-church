#region

using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Commands.PatchPrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class PatchPrivilegeCommandValidator
        : AbstractValidator<PatchPrivilegeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public PatchPrivilegeCommandValidator(IAppDbContext appDbContext)
        {
            //this.RuleFor(r => r.Id)
            //   .GreaterThan(0);
        }
    }
}
