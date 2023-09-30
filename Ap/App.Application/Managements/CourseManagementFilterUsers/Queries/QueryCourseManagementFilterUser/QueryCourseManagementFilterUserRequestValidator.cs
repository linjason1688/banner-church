#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Queries.QueryCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementFilterUserRequestValidator 
        : AbstractValidator<QueryCourseManagementFilterUserRequest>
    {
        public QueryCourseManagementFilterUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
