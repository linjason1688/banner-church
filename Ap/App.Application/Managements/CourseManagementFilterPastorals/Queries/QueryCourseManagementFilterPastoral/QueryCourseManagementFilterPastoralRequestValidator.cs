#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterPastorals.Queries.QueryCourseManagementFilterPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementFilterPastoralRequestValidator 
        : AbstractValidator<QueryCourseManagementFilterPastoralRequest>
    {
        public QueryCourseManagementFilterPastoralRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
