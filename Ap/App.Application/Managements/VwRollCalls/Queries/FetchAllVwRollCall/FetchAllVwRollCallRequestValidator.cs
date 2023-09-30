#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwRollCalls.Queries.FetchAllVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwRollCallRequestValidator 
        : AbstractValidator<FetchAllVwRollCallRequest>
    {
        public FetchAllVwRollCallRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
