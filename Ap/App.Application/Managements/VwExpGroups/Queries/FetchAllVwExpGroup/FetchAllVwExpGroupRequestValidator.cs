#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwExpGroups.Queries.FetchAllVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwExpGroupRequestValidator 
        : AbstractValidator<FetchAllVwExpGroupRequest>
    {
        public FetchAllVwExpGroupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
