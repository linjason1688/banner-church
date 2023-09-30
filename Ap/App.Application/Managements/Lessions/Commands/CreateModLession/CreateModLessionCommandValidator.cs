#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Lessions.ModLessions.Commands.CreateModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionCommandValidator 
        : AbstractValidator<CreateModLessionCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLession, e => e.Name)
            //     );
        }
    }
}
