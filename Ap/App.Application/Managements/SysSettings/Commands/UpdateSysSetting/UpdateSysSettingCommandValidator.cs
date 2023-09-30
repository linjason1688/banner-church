#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSettings.Commands.UpdateSysSetting
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysSettingCommandValidator 
        : AbstractValidator<UpdateSysSettingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysSettingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSetting, e => e.Name)
            //     );
        }
    }
}
