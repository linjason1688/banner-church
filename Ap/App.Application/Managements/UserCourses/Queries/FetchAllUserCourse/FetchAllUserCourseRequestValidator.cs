#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserCourses.Queries.FetchAllUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserCourseRequestValidator 
        : AbstractValidator<FetchAllUserCourseRequest>
    {
        public FetchAllUserCourseRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
