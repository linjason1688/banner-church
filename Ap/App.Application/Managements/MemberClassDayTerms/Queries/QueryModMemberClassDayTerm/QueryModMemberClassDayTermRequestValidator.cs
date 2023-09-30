#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Queries.QueryModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberClassDayTermRequestValidator 
        : AbstractValidator<QueryModMemberClassDayTermRequest>
    {
        public QueryModMemberClassDayTermRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
