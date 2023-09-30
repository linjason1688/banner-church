#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrganizations.Queries.FindSysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysOrganizationRequestValidator 
        : AbstractValidator<FindSysOrganizationRequest>
    {
        public FindSysOrganizationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
