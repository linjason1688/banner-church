#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagements.Queries.FetchAllCourseManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementRequestValidator 
        : AbstractValidator<FetchAllCourseManagementRequest>
    {
        public FetchAllCourseManagementRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
