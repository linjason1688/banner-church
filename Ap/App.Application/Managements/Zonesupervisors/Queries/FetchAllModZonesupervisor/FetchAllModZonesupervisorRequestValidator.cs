#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Queries.FetchAllModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModZonesupervisorRequestValidator 
        : AbstractValidator<FetchAllModZonesupervisorRequest>
    {
        public FetchAllModZonesupervisorRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
