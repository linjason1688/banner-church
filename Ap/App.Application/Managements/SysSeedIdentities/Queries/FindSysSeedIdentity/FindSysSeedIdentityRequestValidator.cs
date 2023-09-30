#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Queries.FindSysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysSeedIdentityRequestValidator 
        : AbstractValidator<FindSysSeedIdentityRequest>
    {
        public FindSysSeedIdentityRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
