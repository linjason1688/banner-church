#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Queries.FetchAllVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAspnetWebPartStateUserRequestValidator 
        : AbstractValidator<FetchAllVwAspnetWebPartStateUserRequest>
    {
        public FetchAllVwAspnetWebPartStateUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
