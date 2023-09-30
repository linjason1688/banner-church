#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.DeleteRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteRoleUserMappingCommandValidator 
        : AbstractValidator<DeleteRoleUserMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteRoleUserMappingCommandValidator()
        {
            this.RuleFor(r => r.Id)
                  //.GreaterThan(0);
                  .NotEmpty();
        }
    }
}
