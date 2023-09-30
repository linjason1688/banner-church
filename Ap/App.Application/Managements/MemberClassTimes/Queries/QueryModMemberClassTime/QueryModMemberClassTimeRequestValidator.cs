#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Queries.QueryModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberClassTimeRequestValidator 
        : AbstractValidator<QueryModMemberClassTimeRequest>
    {
        public QueryModMemberClassTimeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
