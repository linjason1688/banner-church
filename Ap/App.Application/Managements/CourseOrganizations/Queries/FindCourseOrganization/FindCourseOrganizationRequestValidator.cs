#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseOrganizations.Queries.FindCourseOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseOrganizationRequestValidator 
        : AbstractValidator<FindCourseOrganizationRequest>
    {
        public FindCourseOrganizationRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
