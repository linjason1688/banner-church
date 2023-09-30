#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUsers.Queries.FetchAllSecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSecUserRequestValidator 
        : AbstractValidator<FetchAllSecUserRequest>
    {
        public FetchAllSecUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
