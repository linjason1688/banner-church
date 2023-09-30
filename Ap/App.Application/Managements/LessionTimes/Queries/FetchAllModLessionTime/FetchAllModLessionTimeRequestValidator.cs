#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Queries.FetchAllModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLessionTimeRequestValidator 
        : AbstractValidator<FetchAllModLessionTimeRequest>
    {
        public FetchAllModLessionTimeRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
