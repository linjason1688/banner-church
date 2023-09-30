#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Queries.FetchAllAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetPersonalizationAllUserRequestValidator 
        : AbstractValidator<FetchAllAspnetPersonalizationAllUserRequest>
    {
        public FetchAllAspnetPersonalizationAllUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
