#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Commands.CreateModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModNewcommerCommandValidator 
        : AbstractValidator<CreateModNewcommerCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModNewcommerCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModNewcommer, e => e.Name)
            //     );
        }
    }
}
