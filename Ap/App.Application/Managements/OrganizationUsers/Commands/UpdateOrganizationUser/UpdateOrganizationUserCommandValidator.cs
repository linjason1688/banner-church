#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrganizationUsers.Commands.UpdateOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateOrganizationUserCommandValidator 
        : AbstractValidator<UpdateOrganizationUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateOrganizationUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.OrganizationUser, e => e.Name)
            //     );
        }
    }
}
