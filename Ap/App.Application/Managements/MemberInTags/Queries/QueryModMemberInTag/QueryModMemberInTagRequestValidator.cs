#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Queries.QueryModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberInTagRequestValidator 
        : AbstractValidator<QueryModMemberInTagRequest>
    {
        public QueryModMemberInTagRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
