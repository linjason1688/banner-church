#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Commands.UpdateVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetUsersInRoleCommandValidator 
        : AbstractValidator<UpdateVwAspnetUsersInRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetUsersInRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetUsersInRole, e => e.Name)
            //     );
        }
    }
}
