#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.FindMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryRespRequestValidator 
        : AbstractValidator<FindMinistryRespRequest>
    {
        public FindMinistryRespRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
