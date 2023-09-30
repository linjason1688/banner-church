#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Queries.FetchAllPastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllPastoralRequestValidator 
        : AbstractValidator<FetchAllPastoralRequest>
    {
        public FetchAllPastoralRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
