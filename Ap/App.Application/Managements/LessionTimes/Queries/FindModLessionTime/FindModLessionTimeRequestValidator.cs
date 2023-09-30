#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Queries.FindModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModLessionTimeRequestValidator 
        : AbstractValidator<FindModLessionTimeRequest>
    {
        public FindModLessionTimeRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
