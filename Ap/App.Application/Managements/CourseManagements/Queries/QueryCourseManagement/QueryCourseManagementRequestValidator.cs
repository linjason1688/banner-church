#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagements.Queries.QueryCourseManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementRequestValidator 
        : AbstractValidator<QueryCourseManagementRequest>
    {
        public QueryCourseManagementRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
