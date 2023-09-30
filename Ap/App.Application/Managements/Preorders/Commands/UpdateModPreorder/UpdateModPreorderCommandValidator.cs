#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Commands.UpdateModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModPreorderCommandValidator 
        : AbstractValidator<UpdateModPreorderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModPreorderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModPreorder, e => e.Name)
            //     );
        }
    }
}
