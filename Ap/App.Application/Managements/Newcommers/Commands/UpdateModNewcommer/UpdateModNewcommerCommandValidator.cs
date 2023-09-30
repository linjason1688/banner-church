#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Commands.UpdateModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModNewcommerCommandValidator 
        : AbstractValidator<UpdateModNewcommerCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModNewcommerCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModNewcommer, e => e.Name)
            //     );
        }
    }
}
