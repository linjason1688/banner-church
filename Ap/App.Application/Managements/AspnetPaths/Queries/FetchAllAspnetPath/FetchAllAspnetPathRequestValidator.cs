#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPaths.Queries.FetchAllAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetPathRequestValidator 
        : AbstractValidator<FetchAllAspnetPathRequest>
    {
        public FetchAllAspnetPathRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
