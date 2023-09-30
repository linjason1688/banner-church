#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.UpdateModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModZoneleaderCommandValidator 
        : AbstractValidator<UpdateModZoneleaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModZoneleaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZoneleader, e => e.Name)
            //     );
        }
    }
}
