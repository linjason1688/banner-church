#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSettings.Queries.FetchAllSysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllSysSettingRequestValidator 
        : AbstractValidator<FetchAllSysSettingRequest>
    {
        public FetchAllSysSettingRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
