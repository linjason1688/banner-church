#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUserRoles.Commands.UpdateSecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSecUserRoleCommandValidator 
        : AbstractValidator<UpdateSecUserRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSecUserRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecUserRole, e => e.Name)
            //     );
        }
    }
}
