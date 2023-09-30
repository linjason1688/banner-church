#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Queries.FindModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModArealeaderRequestValidator 
        : AbstractValidator<FindModArealeaderRequest>
    {
        public FindModArealeaderRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
