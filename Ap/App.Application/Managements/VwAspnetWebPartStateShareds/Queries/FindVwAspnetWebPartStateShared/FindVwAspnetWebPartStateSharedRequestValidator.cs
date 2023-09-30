#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Queries.FindVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetWebPartStateSharedRequestValidator 
        : AbstractValidator<FindVwAspnetWebPartStateSharedRequest>
    {
        public FindVwAspnetWebPartStateSharedRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
