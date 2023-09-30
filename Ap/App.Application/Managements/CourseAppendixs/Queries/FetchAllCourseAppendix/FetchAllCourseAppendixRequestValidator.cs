#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseAppendixs.Queries.FetchAllCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseAppendixRequestValidator 
        : AbstractValidator<FetchAllCourseAppendixRequest>
    {
        public FetchAllCourseAppendixRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
