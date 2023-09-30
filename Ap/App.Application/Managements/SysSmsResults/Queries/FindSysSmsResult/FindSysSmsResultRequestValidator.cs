#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSmsResults.Queries.FindSysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysSmsResultRequestValidator 
        : AbstractValidator<FindSysSmsResultRequest>
    {
        public FindSysSmsResultRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
