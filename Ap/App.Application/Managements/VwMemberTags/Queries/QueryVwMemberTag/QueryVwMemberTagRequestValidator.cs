#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberTags.Queries.QueryVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwMemberTagRequestValidator 
        : AbstractValidator<QueryVwMemberTagRequest>
    {
        public QueryVwMemberTagRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
