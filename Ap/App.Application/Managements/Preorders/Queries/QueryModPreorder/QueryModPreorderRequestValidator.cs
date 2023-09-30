#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Queries.QueryModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModPreorderRequestValidator 
        : AbstractValidator<QueryModPreorderRequest>
    {
        public QueryModPreorderRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
