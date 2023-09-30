#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.Queries.QueryTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryTeacherRequestValidator 
        : AbstractValidator<QueryTeacherRequest>
    {
        public QueryTeacherRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
