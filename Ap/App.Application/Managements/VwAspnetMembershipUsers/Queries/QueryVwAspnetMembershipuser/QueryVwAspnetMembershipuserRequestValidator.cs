#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Queries.QueryVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetMembershipuserRequestValidator 
        : AbstractValidator<QueryVwAspnetMembershipuserRequest>
    {
        public QueryVwAspnetMembershipuserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
