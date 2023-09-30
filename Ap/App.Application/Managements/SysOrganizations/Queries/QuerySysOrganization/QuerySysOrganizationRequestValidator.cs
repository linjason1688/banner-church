#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrganizations.Queries.QuerySysOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysOrganizationRequestValidator 
        : AbstractValidator<QuerySysOrganizationRequest>
    {
        public QuerySysOrganizationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
