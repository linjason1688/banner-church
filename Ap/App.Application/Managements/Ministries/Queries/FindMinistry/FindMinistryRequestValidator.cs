#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministries.Queries.FindMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryRequestValidator 
        : AbstractValidator<FindMinistryRequest>
    {
        public FindMinistryRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
