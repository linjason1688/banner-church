#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Queries.QueryModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModCareerRequestValidator 
        : AbstractValidator<QueryModCareerRequest>
    {
        public QueryModCareerRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
