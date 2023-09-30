#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Activities.ModActivities.Queries.FetchAllModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModActivityRequestValidator 
        : AbstractValidator<FetchAllModActivityRequest>
    {
        public FetchAllModActivityRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
