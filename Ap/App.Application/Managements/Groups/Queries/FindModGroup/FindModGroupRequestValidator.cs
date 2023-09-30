#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Queries.FindModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModGroupRequestValidator 
        : AbstractValidator<FindModGroupRequest>
    {
        public FindModGroupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
