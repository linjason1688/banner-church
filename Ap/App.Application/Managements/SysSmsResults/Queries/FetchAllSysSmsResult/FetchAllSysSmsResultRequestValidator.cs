#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSmsResults.Queries.FetchAllSysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysSmsResultRequestValidator 
        : AbstractValidator<FetchAllSysSmsResultRequest>
    {
        public FetchAllSysSmsResultRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
