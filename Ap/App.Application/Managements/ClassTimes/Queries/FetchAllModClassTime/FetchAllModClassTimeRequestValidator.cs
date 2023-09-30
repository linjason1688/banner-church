#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Queries.FetchAllModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassTimeRequestValidator 
        : AbstractValidator<FetchAllModClassTimeRequest>
    {
        public FetchAllModClassTimeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
