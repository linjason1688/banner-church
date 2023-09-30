#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetRoles.Commands.CreateVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetRoleCommandValidator 
        : AbstractValidator<CreateVwAspnetRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetRole, e => e.Name)
            //     );
        }
    }
}
