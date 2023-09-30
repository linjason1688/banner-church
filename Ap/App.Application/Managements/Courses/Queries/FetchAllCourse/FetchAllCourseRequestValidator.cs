#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Courses.Queries.FetchAllCourse
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseRequestValidator 
        : AbstractValidator<FetchAllCourseRequest>
    {
        public FetchAllCourseRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
