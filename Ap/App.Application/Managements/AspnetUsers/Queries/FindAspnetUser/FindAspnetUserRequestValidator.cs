#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsers.Queries.FindAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetUserRequestValidator 
        : AbstractValidator<FindAspnetUserRequest>
    {
        public FindAspnetUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
