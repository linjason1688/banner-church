#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Queries.FetchAllVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetWebPartStatePathRequestValidator 
        : AbstractValidator<FetchAllVwAspnetWebPartStatePathRequest>
    {
        public FetchAllVwAspnetWebPartStatePathRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
