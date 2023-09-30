#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Queries.QueryModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModZoneleaderRequestValidator 
        : AbstractValidator<QueryModZoneleaderRequest>
    {
        public QueryModZoneleaderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
