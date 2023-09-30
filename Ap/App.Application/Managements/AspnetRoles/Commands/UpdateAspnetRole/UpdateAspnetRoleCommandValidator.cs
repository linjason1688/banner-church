#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetRoles.Commands.UpdateAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetRoleCommandValidator 
        : AbstractValidator<UpdateAspnetRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetRole, e => e.Name)
            //     );
        }
    }
}
