#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserFamilies.Queries.FindUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserFamilyRequestValidator 
        : AbstractValidator<FindUserFamilyRequest>
    {
        public FindUserFamilyRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
