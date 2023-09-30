#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.FetchAllMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryRespUserRequestValidator 
        : AbstractValidator<FetchAllMinistryRespUserRequest>
    {
        public FetchAllMinistryRespUserRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
