#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Queries.FindModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModExpgroupRequestValidator 
        : AbstractValidator<FindModExpgroupRequest>
    {
        public FindModExpgroupRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
