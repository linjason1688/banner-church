#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Queries.FetchAllVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetWebPartStateSharedRequestValidator 
        : AbstractValidator<FetchAllVwAspnetWebPartStateSharedRequest>
    {
        public FetchAllVwAspnetWebPartStateSharedRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
