#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Queries.FetchAllModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModGroupleaderRequestValidator 
        : AbstractValidator<FetchAllModGroupleaderRequest>
    {
        public FetchAllModGroupleaderRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
