#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Privileges.Commands.CreatePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePrivilegeCommandValidator 
        : AbstractValidator<CreatePrivilegeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreatePrivilegeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Privilege, e => e.Name)
            //     );
        }
    }
}
