#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrganizations.Commands.UpdateSysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysOrganizationCommandValidator 
        : AbstractValidator<UpdateSysOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysOrganization, e => e.Name)
            //     );
        }
    }
}
