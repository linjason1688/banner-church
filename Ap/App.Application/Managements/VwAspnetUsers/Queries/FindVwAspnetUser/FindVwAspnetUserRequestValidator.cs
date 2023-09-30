#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Queries.FindVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetUserRequestValidator 
        : AbstractValidator<FindVwAspnetUserRequest>
    {
        public FindVwAspnetUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
