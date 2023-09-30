#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SecUserRoles.Commands.CreateSecUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSecUserRoleCommandValidator 
        : AbstractValidator<CreateSecUserRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSecUserRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecUserRole, e => e.Name)
            //     );
        }
    }
}
