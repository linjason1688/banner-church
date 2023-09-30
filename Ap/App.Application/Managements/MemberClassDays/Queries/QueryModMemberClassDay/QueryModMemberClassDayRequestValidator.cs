#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Queries.QueryModMemberClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberClassDayRequestValidator 
        : AbstractValidator<QueryModMemberClassDayRequest>
    {
        public QueryModMemberClassDayRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
