#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSettings.Commands.DeleteSysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysSettingCommandValidator 
        : AbstractValidator<DeleteSysSettingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysSettingCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
