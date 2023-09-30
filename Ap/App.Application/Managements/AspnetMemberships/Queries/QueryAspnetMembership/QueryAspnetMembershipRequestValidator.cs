#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetMemberships.Queries.QueryAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetMembershipRequestValidator 
        : AbstractValidator<QueryAspnetMembershipRequest>
    {
        public QueryAspnetMembershipRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
