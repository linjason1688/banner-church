#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilters.Queries.QueryCourseManagementFilter
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementFilterRequestValidator 
        : AbstractValidator<QueryCourseManagementFilterRequest>
    {
        public QueryCourseManagementFilterRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
