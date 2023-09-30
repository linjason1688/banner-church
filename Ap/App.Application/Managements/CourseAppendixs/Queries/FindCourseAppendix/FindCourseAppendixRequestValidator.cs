#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseAppendixs.Queries.FindCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseAppendixRequestValidator 
        : AbstractValidator<FindCourseAppendixRequest>
    {
        public FindCourseAppendixRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
