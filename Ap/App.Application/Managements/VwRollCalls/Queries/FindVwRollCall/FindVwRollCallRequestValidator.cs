#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwRollCalls.Queries.FindVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwRollCallRequestValidator 
        : AbstractValidator<FindVwRollCallRequest>
    {
        public FindVwRollCallRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
