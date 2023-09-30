#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Zones.ModZones.Commands.CreateModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModZoneCommandValidator 
        : AbstractValidator<CreateModZoneCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModZoneCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZone, e => e.Name)
            //     );
        }
    }
}
