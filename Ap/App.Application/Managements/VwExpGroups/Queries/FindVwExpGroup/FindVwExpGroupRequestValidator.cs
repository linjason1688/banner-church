#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwExpGroups.Queries.FindVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwExpGroupRequestValidator 
        : AbstractValidator<FindVwExpGroupRequest>
    {
        public FindVwExpGroupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
