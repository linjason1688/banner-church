#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Commands.UpdateModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModLogCommandValidator 
        : AbstractValidator<UpdateModLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLog, e => e.Name)
            //     );
        }
    }
}
