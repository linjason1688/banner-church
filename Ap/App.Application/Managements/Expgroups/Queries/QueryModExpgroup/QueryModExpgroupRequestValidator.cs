#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Queries.QueryModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModExpgroupRequestValidator 
        : AbstractValidator<QueryModExpgroupRequest>
    {
        public QueryModExpgroupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
