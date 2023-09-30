#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.FetchAllUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserExpertiseRequestValidator 
        : AbstractValidator<FetchAllUserExpertiseRequest>
    {
        public FetchAllUserExpertiseRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
