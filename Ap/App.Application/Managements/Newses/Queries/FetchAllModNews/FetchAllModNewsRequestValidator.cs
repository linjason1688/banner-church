#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Queries.FetchAllModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModNewsRequestValidator 
        : AbstractValidator<FetchAllModNewsRequest>
    {
        public FetchAllModNewsRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
