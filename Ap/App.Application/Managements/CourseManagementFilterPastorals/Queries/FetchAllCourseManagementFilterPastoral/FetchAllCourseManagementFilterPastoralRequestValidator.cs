#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Queries.FetchAllCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementFilterPastoralRequestValidator 
        : AbstractValidator<FetchAllCourseManagementFilterPastoralRequest>
    {
        public FetchAllCourseManagementFilterPastoralRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
