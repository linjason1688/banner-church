#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Queries.FindModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModClassTimeRequestValidator 
        : AbstractValidator<FindModClassTimeRequest>
    {
        public FindModClassTimeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
