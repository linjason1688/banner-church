#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Queries.FetchAllModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModActivityWorkShareRequestValidator 
        : AbstractValidator<FetchAllModActivityWorkShareRequest>
    {
        public FetchAllModActivityWorkShareRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
