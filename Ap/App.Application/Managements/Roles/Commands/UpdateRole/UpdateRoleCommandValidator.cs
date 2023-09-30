#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Roles.Commands.UpdateRole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateRoleCommandValidator 
        : AbstractValidator<UpdateRoleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .NotNull();

            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Role, e => e.Name)
            //     );
        }
    }
}
