#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Queries.FindModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModNewsRequestValidator 
        : AbstractValidator<FindModNewsRequest>
    {
        public FindModNewsRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
