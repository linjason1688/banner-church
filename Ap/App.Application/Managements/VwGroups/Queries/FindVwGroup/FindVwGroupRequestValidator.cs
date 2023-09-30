#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwGroups.Queries.FindVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwGroupRequestValidator 
        : AbstractValidator<FindVwGroupRequest>
    {
        public FindVwGroupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
