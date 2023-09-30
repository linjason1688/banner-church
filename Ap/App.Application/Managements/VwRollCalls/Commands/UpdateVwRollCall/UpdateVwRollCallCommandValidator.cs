#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwRollCalls.Commands.UpdateVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwRollCallCommandValidator 
        : AbstractValidator<UpdateVwRollCallCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwRollCallCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwRollCall, e => e.Name)
            //     );
        }
    }
}
