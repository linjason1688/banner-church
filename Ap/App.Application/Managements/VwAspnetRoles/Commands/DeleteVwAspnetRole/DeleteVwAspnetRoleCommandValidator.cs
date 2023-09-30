#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetRoles.Commands.DeleteVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetRoleCommandValidator 
        : AbstractValidator<DeleteVwAspnetRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
