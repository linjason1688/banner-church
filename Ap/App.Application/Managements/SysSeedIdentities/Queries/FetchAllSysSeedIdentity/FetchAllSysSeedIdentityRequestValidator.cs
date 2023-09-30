#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Queries.FetchAllSysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysSeedIdentityRequestValidator 
        : AbstractValidator<FetchAllSysSeedIdentityRequest>
    {
        public FetchAllSysSeedIdentityRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
