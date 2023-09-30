#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Queries.QueryVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetApplicationRequestValidator 
        : AbstractValidator<QueryVwAspnetApplicationRequest>
    {
        public QueryVwAspnetApplicationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
