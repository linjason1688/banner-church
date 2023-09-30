#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementAppendixs.Queries.QueryCourseManagementAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseManagementAppendixRequestValidator 
        : AbstractValidator<QueryCourseManagementAppendixRequest>
    {
        public QueryCourseManagementAppendixRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
