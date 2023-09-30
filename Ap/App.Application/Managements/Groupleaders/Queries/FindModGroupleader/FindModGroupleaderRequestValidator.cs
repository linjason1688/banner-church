#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Queries.FindModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModGroupleaderRequestValidator 
        : AbstractValidator<FindModGroupleaderRequest>
    {
        public FindModGroupleaderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
