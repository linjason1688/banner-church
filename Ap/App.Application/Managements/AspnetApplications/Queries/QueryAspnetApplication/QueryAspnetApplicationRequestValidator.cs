#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetApplications.Queries.QueryAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetApplicationRequestValidator 
        : AbstractValidator<QueryAspnetApplicationRequest>
    {
        public QueryAspnetApplicationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
