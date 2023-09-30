#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Queries.FindCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class FindCourseManagementFilterRespRequestValidator 
        : AbstractValidator<FindCourseManagementFilterRespRequest>
    {
        public FindCourseManagementFilterRespRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
