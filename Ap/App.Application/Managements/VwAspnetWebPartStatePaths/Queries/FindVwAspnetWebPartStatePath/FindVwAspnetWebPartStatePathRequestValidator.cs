#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Queries.FindVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetWebPartStatePathRequestValidator 
        : AbstractValidator<FindVwAspnetWebPartStatePathRequest>
    {
        public FindVwAspnetWebPartStatePathRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
