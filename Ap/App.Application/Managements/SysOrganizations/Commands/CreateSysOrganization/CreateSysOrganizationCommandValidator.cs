#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysOrganizations.Commands.CreateSysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysOrganizationCommandValidator 
        : AbstractValidator<CreateSysOrganizationCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysOrganizationCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysOrganization, e => e.Name)
            //     );
        }
    }
}
