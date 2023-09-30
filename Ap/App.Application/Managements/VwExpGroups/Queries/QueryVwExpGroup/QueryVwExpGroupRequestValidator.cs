#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwExpGroups.Queries.QueryVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwExpGroupRequestValidator 
        : AbstractValidator<QueryVwExpGroupRequest>
    {
        public QueryVwExpGroupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
