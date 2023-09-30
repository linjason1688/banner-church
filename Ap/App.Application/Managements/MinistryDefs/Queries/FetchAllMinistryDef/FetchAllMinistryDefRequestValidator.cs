#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryDefs.Queries.FetchAllMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllMinistryDefRequestValidator 
        : AbstractValidator<FetchAllMinistryDefRequest>
    {
        public FetchAllMinistryDefRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
