#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Queries.FindCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterPastoralRequestValidator 
        : AbstractValidator<FindCourseManagementFilterPastoralRequest>
    {
        public FindCourseManagementFilterPastoralRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
