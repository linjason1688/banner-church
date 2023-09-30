#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysSettings.Commands.CreateSysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSettingCommandValidator 
        : AbstractValidator<CreateSysSettingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysSettingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSetting, e => e.Name)
            //     );
        }
    }
}
