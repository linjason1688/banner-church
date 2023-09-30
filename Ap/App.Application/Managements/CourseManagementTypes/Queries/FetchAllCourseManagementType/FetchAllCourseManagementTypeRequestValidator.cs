#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Queries.FetchAllCourseManagementType
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementTypeRequestValidator 
        : AbstractValidator<FetchAllCourseManagementTypeRequest>
    {
        public FetchAllCourseManagementTypeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
