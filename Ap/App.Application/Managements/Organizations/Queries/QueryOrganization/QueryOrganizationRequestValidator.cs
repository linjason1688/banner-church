#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Organizations.Queries.QueryOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryOrganizationRequestValidator 
        : AbstractValidator<QueryOrganizationRequest>
    {
        public QueryOrganizationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
