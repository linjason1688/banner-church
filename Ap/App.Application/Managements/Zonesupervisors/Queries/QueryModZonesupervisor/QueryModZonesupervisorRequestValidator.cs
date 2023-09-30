#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Queries.QueryModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModZonesupervisorRequestValidator 
        : AbstractValidator<QueryModZonesupervisorRequest>
    {
        public QueryModZonesupervisorRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
