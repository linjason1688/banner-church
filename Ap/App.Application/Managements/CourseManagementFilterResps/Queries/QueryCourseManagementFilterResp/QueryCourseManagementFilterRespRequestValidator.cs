#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Queries.QueryCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementFilterRespRequestValidator 
        : AbstractValidator<QueryCourseManagementFilterRespRequest>
    {
        public QueryCourseManagementFilterRespRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
