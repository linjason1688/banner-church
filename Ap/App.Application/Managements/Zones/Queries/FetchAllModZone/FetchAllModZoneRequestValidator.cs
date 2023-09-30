#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zones.ModZones.Queries.FetchAllModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModZoneRequestValidator 
        : AbstractValidator<FetchAllModZoneRequest>
    {
        public FetchAllModZoneRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
