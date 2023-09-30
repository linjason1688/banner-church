#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SystemConfigs.Commands.UpdateSystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSystemConfigCommandValidator 
        : AbstractValidator<UpdateSystemConfigCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSystemConfigCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SystemConfig, e => e.Name)
            //     );
        }
    }
}
