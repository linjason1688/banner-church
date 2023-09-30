#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Commands.UpdateModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModLessionCommandValidator 
        : AbstractValidator<UpdateModLessionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModLessionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLession, e => e.Name)
            //     );
        }
    }
}
