#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetRoles.Commands.DeleteAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetRoleCommandValidator 
        : AbstractValidator<DeleteAspnetRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetRoleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
