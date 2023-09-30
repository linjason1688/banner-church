#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserPastoralCares.Queries.FindUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserPastoralCareRequestValidator 
        : AbstractValidator<FindUserPastoralCareRequest>
    {
        public FindUserPastoralCareRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
