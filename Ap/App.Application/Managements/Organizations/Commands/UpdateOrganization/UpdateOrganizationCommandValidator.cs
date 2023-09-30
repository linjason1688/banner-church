#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Organizations.Commands.UpdateOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateOrganizationCommandValidator 
        : AbstractValidator<UpdateOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Organization, e => e.Name)
            //     );
        }
    }
}
