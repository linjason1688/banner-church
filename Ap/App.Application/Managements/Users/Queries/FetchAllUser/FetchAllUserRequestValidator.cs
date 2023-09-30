#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Users.Queries.FetchAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserRequestValidator 
        : AbstractValidator<FetchAllUserRequest>
    {
        public FetchAllUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
