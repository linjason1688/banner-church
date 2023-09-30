#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Commands.CreateModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModPreorderCommandValidator 
        : AbstractValidator<CreateModPreorderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModPreorderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModPreorder, e => e.Name)
            //     );
        }
    }
}
