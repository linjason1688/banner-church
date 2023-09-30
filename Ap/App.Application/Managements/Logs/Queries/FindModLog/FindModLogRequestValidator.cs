#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Queries.FindModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModLogRequestValidator 
        : AbstractValidator<FindModLogRequest>
    {
        public FindModLogRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
