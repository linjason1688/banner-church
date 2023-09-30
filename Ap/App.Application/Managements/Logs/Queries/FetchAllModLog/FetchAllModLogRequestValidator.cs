#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Queries.FetchAllModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLogRequestValidator 
        : AbstractValidator<FetchAllModLogRequest>
    {
        public FetchAllModLogRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
