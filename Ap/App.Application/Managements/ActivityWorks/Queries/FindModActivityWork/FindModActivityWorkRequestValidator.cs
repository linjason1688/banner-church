#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Queries.FindModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModActivityWorkRequestValidator 
        : AbstractValidator<FindModActivityWorkRequest>
    {
        public FindModActivityWorkRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
