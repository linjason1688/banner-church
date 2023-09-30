#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministries.Queries.FetchAllMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryRequestValidator 
        : AbstractValidator<FetchAllMinistryRequest>
    {
        public FetchAllMinistryRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
