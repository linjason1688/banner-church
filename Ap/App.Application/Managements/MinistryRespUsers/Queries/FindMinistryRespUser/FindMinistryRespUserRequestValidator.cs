#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.FindMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryRespUserRequestValidator 
        : AbstractValidator<FindMinistryRespUserRequest>
    {
        public FindMinistryRespUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
