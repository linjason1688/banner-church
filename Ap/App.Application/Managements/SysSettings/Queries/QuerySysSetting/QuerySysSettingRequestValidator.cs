#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSettings.Queries.QuerySysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySysSettingRequestValidator 
        : AbstractValidator<QuerySysSettingRequest>
    {
        public QuerySysSettingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
