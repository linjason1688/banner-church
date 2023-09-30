#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Commands.UpdateModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModRollcallCommandValidator 
        : AbstractValidator<UpdateModRollcallCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModRollcallCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModRollcall, e => e.Name)
            //     );
        }
    }
}
