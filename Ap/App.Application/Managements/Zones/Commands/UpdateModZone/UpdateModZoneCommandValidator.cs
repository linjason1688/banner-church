#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zones.ModZones.Commands.UpdateModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModZoneCommandValidator 
        : AbstractValidator<UpdateModZoneCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModZoneCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZone, e => e.Name)
            //     );
        }
    }
}
