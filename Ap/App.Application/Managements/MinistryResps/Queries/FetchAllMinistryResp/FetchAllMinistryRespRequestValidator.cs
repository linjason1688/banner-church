#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.FetchAllMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryRespRequestValidator 
        : AbstractValidator<FetchAllMinistryRespRequest>
    {
        public FetchAllMinistryRespRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
