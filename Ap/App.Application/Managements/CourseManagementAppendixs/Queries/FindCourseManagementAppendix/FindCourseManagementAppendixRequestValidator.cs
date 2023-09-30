#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Queries.FindCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementAppendixRequestValidator 
        : AbstractValidator<FindCourseManagementAppendixRequest>
    {
        public FindCourseManagementAppendixRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
