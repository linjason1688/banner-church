#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SecRoles.Commands.CreateSecRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSecRoleCommandValidator 
        : AbstractValidator<CreateSecRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSecRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecRole, e => e.Name)
            //     );
        }
    }
}
