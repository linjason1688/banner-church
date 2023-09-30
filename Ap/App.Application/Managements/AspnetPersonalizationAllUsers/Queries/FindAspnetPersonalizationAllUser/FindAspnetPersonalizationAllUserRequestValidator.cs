#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Queries.FindAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetPersonalizationAllUserRequestValidator 
        : AbstractValidator<FindAspnetPersonalizationAllUserRequest>
    {
        public FindAspnetPersonalizationAllUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
