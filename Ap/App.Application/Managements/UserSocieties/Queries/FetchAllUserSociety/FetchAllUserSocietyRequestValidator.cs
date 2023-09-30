#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserSocieties.Queries.FetchAllUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserSocietyRequestValidator 
        : AbstractValidator<FetchAllUserSocietyRequest>
    {
        public FetchAllUserSocietyRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
