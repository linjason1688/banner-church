#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zones.ModZones.Queries.FindModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModZoneRequestValidator 
        : AbstractValidator<FindModZoneRequest>
    {
        public FindModZoneRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
