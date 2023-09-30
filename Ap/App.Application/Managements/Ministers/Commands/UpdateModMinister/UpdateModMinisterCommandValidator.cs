#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Commands.UpdateModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMinisterCommandValidator 
        : AbstractValidator<UpdateModMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMinister, e => e.Name)
            //     );
        }
    }
}
