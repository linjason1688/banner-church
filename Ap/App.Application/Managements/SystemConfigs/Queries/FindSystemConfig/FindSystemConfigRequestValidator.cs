#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SystemConfigs.Queries.FindSystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSystemConfigRequestValidator 
        : AbstractValidator<FindSystemConfigRequest>
    {
        public FindSystemConfigRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
