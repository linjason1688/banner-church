#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Queries.FindVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetWebPartStateUserRequestValidator 
        : AbstractValidator<FindVwAspnetWebPartStateUserRequest>
    {
        public FindVwAspnetWebPartStateUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
