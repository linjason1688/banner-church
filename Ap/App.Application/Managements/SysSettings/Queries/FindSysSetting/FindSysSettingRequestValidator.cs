#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSettings.Queries.FindSysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class FindSysSettingRequestValidator 
        : AbstractValidator<FindSysSettingRequest>
    {
        public FindSysSettingRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
