#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserSocieties.Queries.FindUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserSocietyRequestValidator 
        : AbstractValidator<FindUserSocietyRequest>
    {
        public FindUserSocietyRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
