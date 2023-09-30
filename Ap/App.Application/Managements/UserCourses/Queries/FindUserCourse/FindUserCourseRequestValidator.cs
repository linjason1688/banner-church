#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserCourses.Queries.FindUserCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserCourseRequestValidator 
        : AbstractValidator<FindUserCourseRequest>
    {
        public FindUserCourseRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
