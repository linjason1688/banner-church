#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Roles.Commands.CreateRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateRoleCommandValidator 
        : AbstractValidator<CreateRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Role, e => e.Name)
            //     );
        }
    }
}
