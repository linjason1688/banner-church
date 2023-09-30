#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zones.ModZones.Queries.QueryModZone
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModZoneRequestValidator 
        : AbstractValidator<QueryModZoneRequest>
    {
        public QueryModZoneRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
