#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Queries.FindAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetPersonalizationPerUserRequestValidator 
        : AbstractValidator<FindAspnetPersonalizationPerUserRequest>
    {
        public FindAspnetPersonalizationPerUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
