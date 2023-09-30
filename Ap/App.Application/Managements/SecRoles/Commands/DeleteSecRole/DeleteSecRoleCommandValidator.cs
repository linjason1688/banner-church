#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecRoles.Commands.DeleteSecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSecRoleCommandValidator 
        : AbstractValidator<DeleteSecRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSecRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
