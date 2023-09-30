#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Privileges.Commands.DeletePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePrivilegeCommandValidator 
        : AbstractValidator<DeletePrivilegeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeletePrivilegeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .NotNull();
        }
    }
}
