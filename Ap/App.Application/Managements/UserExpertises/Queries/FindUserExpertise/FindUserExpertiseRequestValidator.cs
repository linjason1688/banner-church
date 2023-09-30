#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.FindUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserExpertiseRequestValidator 
        : AbstractValidator<FindUserExpertiseRequest>
    {
        public FindUserExpertiseRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
