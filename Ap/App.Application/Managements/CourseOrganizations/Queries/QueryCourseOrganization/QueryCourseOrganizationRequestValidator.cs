#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseOrganizations.Queries.QueryCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseOrganizationRequestValidator 
        : AbstractValidator<QueryCourseOrganizationRequest>
    {
        public QueryCourseOrganizationRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
