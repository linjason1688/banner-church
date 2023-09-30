#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Queries.FetchAllVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetUserRequestValidator 
        : AbstractValidator<FetchAllVwAspnetUserRequest>
    {
        public FetchAllVwAspnetUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
