#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FindPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralRequestValidator 
        : AbstractValidator<FindPastoralRequest>
    {
        public FindPastoralRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
