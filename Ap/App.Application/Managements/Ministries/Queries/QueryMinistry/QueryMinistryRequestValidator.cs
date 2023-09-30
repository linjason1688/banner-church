#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministries.Queries.QueryMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryRequestValidator 
        : AbstractValidator<QueryMinistryRequest>
    {
        public QueryMinistryRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
