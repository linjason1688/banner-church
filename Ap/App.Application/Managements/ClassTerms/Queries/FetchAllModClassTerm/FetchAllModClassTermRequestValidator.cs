#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Queries.FetchAllModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassTermRequestValidator 
        : AbstractValidator<FetchAllModClassTermRequest>
    {
        public FetchAllModClassTermRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
