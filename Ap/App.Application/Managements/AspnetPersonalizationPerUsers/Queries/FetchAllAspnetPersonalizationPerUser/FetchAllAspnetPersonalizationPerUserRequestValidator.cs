#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Queries.FetchAllAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetPersonalizationPerUserRequestValidator 
        : AbstractValidator<FetchAllAspnetPersonalizationPerUserRequest>
    {
        public FetchAllAspnetPersonalizationPerUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
