#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Queries.FetchAllModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModArealeaderRequestValidator 
        : AbstractValidator<FetchAllModArealeaderRequest>
    {
        public FetchAllModArealeaderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
