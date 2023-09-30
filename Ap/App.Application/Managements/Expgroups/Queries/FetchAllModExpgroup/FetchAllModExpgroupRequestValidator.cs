#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Queries.FetchAllModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModExpgroupRequestValidator 
        : AbstractValidator<FetchAllModExpgroupRequest>
    {
        public FetchAllModExpgroupRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
