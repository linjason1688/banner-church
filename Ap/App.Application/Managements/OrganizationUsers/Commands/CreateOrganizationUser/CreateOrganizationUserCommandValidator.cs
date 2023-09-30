#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.OrganizationUsers.Commands.CreateOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateOrganizationUserCommandValidator 
        : AbstractValidator<CreateOrganizationUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateOrganizationUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.OrganizationUser, e => e.Name)
            //     );
        }
    }
}
