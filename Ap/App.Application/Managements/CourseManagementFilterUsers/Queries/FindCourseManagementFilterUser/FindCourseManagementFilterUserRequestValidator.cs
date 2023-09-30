#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Queries.FindCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterUserRequestValidator 
        : AbstractValidator<FindCourseManagementFilterUserRequest>
    {
        public FindCourseManagementFilterUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
