#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwGroups.Queries.QueryVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwGroupRequestValidator 
        : AbstractValidator<QueryVwGroupRequest>
    {
        public QueryVwGroupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
