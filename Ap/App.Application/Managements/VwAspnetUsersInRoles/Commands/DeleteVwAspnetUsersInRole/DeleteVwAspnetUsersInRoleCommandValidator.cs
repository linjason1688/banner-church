#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Commands.DeleteVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetUsersInRoleCommandValidator 
        : AbstractValidator<DeleteVwAspnetUsersInRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetUsersInRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
