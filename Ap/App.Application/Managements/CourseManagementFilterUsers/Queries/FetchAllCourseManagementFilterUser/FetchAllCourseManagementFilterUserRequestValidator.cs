#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterUsers.Queries.FetchAllCourseManagementFilterUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementFilterUserRequestValidator 
        : AbstractValidator<FetchAllCourseManagementFilterUserRequest>
    {
        public FetchAllCourseManagementFilterUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
