#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserPastoralCares.Queries.FetchAllUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserPastoralCareRequestValidator 
        : AbstractValidator<FetchAllUserPastoralCareRequest>
    {
        public FetchAllUserPastoralCareRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
