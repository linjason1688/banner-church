#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Queries.QuerySysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysSeedIdentityRequestValidator 
        : AbstractValidator<QuerySysSeedIdentityRequest>
    {
        public QuerySysSeedIdentityRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
