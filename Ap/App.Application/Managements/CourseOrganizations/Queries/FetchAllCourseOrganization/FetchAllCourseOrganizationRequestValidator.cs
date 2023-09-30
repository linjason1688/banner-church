#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseOrganizations.Queries.FetchAllCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseOrganizationRequestValidator 
        : AbstractValidator<FetchAllCourseOrganizationRequest>
    {
        public FetchAllCourseOrganizationRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
