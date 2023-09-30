#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Queries.FindModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModTeacherRequestValidator 
        : AbstractValidator<FindModTeacherRequest>
    {
        public FindModTeacherRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
