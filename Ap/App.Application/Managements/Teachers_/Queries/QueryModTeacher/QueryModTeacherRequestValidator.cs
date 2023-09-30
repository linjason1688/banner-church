#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Queries.QueryModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModTeacherRequestValidator 
        : AbstractValidator<QueryModTeacherRequest>
    {
        public QueryModTeacherRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
