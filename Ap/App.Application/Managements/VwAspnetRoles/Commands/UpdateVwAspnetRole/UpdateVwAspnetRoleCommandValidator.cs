#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetRoles.Commands.UpdateVwAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetRoleCommandValidator 
        : AbstractValidator<UpdateVwAspnetRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetRole, e => e.Name)
            //     );
        }
    }
}
