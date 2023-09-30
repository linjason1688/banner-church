#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Queries.QueryModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModGroupRequestValidator 
        : AbstractValidator<QueryModGroupRequest>
    {
        public QueryModGroupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
