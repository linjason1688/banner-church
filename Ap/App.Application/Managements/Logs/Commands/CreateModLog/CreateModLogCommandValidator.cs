#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Logs.ModLogs.Commands.CreateModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModLogCommandValidator 
        : AbstractValidator<CreateModLogCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLog, e => e.Name)
            //     );
        }
    }
}
