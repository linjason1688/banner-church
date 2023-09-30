#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Queries.FindModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModAreaRequestValidator 
        : AbstractValidator<FindModAreaRequest>
    {
        public FindModAreaRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
