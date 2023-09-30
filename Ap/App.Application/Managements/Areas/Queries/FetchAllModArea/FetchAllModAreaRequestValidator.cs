#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Queries.FetchAllModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModAreaRequestValidator 
        : AbstractValidator<FetchAllModAreaRequest>
    {
        public FetchAllModAreaRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
