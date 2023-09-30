#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Queries.FindModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModZonesupervisorRequestValidator 
        : AbstractValidator<FindModZonesupervisorRequest>
    {
        public FindModZonesupervisorRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
