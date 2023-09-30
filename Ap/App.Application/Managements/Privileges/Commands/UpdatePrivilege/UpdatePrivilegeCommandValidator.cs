#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Commands.UpdatePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePrivilegeCommandValidator
        : AbstractValidator<UpdatePrivilegeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public UpdatePrivilegeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .NotNull();

            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Privilege, e => e.Name)
            //     );
        }
    }
}
