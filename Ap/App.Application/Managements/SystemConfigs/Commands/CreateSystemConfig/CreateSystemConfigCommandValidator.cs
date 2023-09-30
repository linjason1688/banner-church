#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SystemConfigs.Commands.CreateSystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSystemConfigCommandValidator 
        : AbstractValidator<CreateSystemConfigCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSystemConfigCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SystemConfig, e => e.Name)
            //     );
        }
    }
}
