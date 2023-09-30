#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagements.Queries.FindCourseManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementRequestValidator 
        : AbstractValidator<FindCourseManagementRequest>
    {
        public FindCourseManagementRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
