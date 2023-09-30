#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Queries.FindCourseManagementType
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementTypeRequestValidator 
        : AbstractValidator<FindCourseManagementTypeRequest>
    {
        public FindCourseManagementTypeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
