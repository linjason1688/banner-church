#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseAppendixs.Queries.QueryCourseAppendix
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryCourseAppendixRequestValidator 
        : AbstractValidator<QueryCourseAppendixRequest>
    {
        public QueryCourseAppendixRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
