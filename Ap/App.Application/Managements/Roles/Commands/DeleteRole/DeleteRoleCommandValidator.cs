#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Commands.DeleteRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteRoleCommandValidator 
        : AbstractValidator<DeleteRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .NotNull();
        }
    }
}
