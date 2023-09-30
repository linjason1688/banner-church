#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUsers.Queries.FindSecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSecUserRequestValidator 
        : AbstractValidator<FindSecUserRequest>
    {
        public FindSecUserRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
