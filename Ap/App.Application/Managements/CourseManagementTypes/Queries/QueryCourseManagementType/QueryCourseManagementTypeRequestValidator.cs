#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementTypes.Queries.QueryCourseManagementType
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementTypeRequestValidator 
        : AbstractValidator<QueryCourseManagementTypeRequest>
    {
        public QueryCourseManagementTypeRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
