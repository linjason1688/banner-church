#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.FetchAllSystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSystemConfigRequestValidator 
        : AbstractValidator<FetchAllSystemConfigRequest>
    {
        public FetchAllSystemConfigRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
