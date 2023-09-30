#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Queries.FetchAllCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementAppendixRequestValidator 
        : AbstractValidator<FetchAllCourseManagementAppendixRequest>
    {
        public FetchAllCourseManagementAppendixRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
