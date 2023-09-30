#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.UpdateModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModRollcallWorkCommandValidator 
        : AbstractValidator<UpdateModRollcallWorkCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModRollcallWorkCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModRollcallWork, e => e.Name)
            //     );
        }
    }
}
