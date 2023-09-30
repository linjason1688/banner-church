#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Teachers.Queries.FetchAllTeacher
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllTeacherRequestValidator 
        : AbstractValidator<FetchAllTeacherRequest>
    {
        public FetchAllTeacherRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
