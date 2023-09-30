#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetRoles.Commands.CreateAspnetRole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetRoleCommandValidator 
        : AbstractValidator<CreateAspnetRoleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetRole, e => e.Name)
            //     );
        }
    }
}
