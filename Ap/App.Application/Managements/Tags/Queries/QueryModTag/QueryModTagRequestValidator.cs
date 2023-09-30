#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Tags.ModTags.Queries.QueryModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModTagRequestValidator 
        : AbstractValidator<QueryModTagRequest>
    {
        public QueryModTagRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
