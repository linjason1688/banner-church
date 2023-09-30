#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrganizations.Queries.FetchAllSysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysOrganizationRequestValidator 
        : AbstractValidator<FetchAllSysOrganizationRequest>
    {
        public FetchAllSysOrganizationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
