#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Courses.Queries.FindCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseRequestValidator 
        : AbstractValidator<FindCourseRequest>
    {
        public FindCourseRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
