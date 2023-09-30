#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.RoleUserMappings.Commands.UpdateRoleUserMapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateRoleUserMappingCommandValidator 
        : AbstractValidator<UpdateRoleUserMappingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateRoleUserMappingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
              .NotEmpty();

            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.RoleUserMapping, e => e.Name)
            //     );
        }
    }
}
