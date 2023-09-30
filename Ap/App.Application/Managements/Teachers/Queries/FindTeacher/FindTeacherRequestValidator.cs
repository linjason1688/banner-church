#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.Queries.FindTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FindTeacherRequestValidator 
        : AbstractValidator<FindTeacherRequest>
    {
        public FindTeacherRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
