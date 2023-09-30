#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Queries.FindModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModClassTermRequestValidator 
        : AbstractValidator<FindModClassTermRequest>
    {
        public FindModClassTermRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
