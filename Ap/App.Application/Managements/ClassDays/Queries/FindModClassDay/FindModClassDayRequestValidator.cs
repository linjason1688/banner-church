#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Queries.FindModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModClassDayRequestValidator 
        : AbstractValidator<FindModClassDayRequest>
    {
        public FindModClassDayRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
