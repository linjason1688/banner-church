#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecRoles.Commands.UpdateSecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSecRoleCommandValidator 
        : AbstractValidator<UpdateSecRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSecRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecRole, e => e.Name)
            //     );
        }
    }
}
