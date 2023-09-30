#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Organizations.Commands.CreateOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateOrganizationCommandValidator 
        : AbstractValidator<CreateOrganizationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Organization, e => e.Name)
            //     );
        }
    }
}
