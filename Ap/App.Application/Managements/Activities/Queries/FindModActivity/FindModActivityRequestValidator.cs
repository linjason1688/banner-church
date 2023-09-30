#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Activities.ModActivities.Queries.FindModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityRequestValidator 
        : AbstractValidator<FindModActivityRequest>
    {
        public FindModActivityRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
