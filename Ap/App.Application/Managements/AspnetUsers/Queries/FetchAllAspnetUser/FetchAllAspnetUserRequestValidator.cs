#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsers.Queries.FetchAllAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetUserRequestValidator 
        : AbstractValidator<FetchAllAspnetUserRequest>
    {
        public FetchAllAspnetUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
