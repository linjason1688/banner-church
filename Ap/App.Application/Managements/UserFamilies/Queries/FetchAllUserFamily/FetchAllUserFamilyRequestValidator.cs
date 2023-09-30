#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserFamilies.Queries.FetchAllUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserFamilyRequestValidator 
        : AbstractValidator<FetchAllUserFamilyRequest>
    {
        public FetchAllUserFamilyRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
