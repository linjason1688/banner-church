#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrganizations.Commands.DeleteSysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysOrganizationCommandValidator 
        : AbstractValidator<DeleteSysOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysOrganizationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
