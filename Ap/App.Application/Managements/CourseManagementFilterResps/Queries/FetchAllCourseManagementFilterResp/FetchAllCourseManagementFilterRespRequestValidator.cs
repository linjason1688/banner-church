#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Queries.FetchAllCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseManagementFilterRespRequestValidator 
        : AbstractValidator<FetchAllCourseManagementFilterRespRequest>
    {
        public FetchAllCourseManagementFilterRespRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
