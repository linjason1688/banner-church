#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.ModTeachers.Queries.FetchAllModTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModTeacherRequestValidator 
        : AbstractValidator<FetchAllModTeacherRequest>
    {
        public FetchAllModTeacherRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
