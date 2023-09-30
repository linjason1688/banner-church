#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetUsersInRoles.Commands.CreateVwAspnetUsersInRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetUsersInRoleCommandValidator 
        : AbstractValidator<CreateVwAspnetUsersInRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetUsersInRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetUsersInRole, e => e.Name)
            //     );
        }
    }
}
