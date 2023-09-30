#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Queries.FetchAllModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModActivityWorkRequestValidator 
        : AbstractValidator<FetchAllModActivityWorkRequest>
    {
        public FetchAllModActivityWorkRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
