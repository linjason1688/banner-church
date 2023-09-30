#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zones.ModZones.Commands.DeleteModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModZoneCommandValidator 
        : AbstractValidator<DeleteModZoneCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModZoneCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
