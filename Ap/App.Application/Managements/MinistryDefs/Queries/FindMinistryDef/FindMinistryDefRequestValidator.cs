#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryDefs.Queries.FindMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryDefRequestValidator 
        : AbstractValidator<FindMinistryDefRequest>
    {
        public FindMinistryDefRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
