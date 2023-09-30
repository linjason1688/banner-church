#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Queries.QueryModMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberClassRequestValidator 
        : AbstractValidator<QueryModMemberClassRequest>
    {
        public QueryModMemberClassRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
