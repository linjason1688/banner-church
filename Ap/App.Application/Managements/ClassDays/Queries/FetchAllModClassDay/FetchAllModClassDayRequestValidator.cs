#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Queries.FetchAllModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassDayRequestValidator 
        : AbstractValidator<FetchAllModClassDayRequest>
    {
        public FetchAllModClassDayRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
