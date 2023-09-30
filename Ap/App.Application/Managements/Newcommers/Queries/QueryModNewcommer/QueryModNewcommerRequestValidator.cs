#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Queries.QueryModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModNewcommerRequestValidator 
        : AbstractValidator<QueryModNewcommerRequest>
    {
        public QueryModNewcommerRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
