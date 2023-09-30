#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Queries.FindModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityWorkShareRequestValidator 
        : AbstractValidator<FindModActivityWorkShareRequest>
    {
        public FindModActivityWorkShareRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
