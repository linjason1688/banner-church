#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Users.Queries.FindUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserRequestValidator 
        : AbstractValidator<FindUserRequest>
    {
        public FindUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
