#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUserRoles.Commands.DeleteSecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSecUserRoleCommandValidator 
        : AbstractValidator<DeleteSecUserRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSecUserRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
