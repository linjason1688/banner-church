#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.CreateRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateRoleUserMappingCommandValidator 
        : AbstractValidator<CreateRoleUserMappingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateRoleUserMappingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.RoleUserMapping, e => e.Name)
            //     );
        }
    }
}
