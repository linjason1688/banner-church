#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwGroups.Queries.FetchAllVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwGroupRequestValidator 
        : AbstractValidator<FetchAllVwGroupRequest>
    {
        public FetchAllVwGroupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
