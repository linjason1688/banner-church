#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Queries.FindVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwZoneSupervisorRequestValidator 
        : AbstractValidator<FindVwZoneSupervisorRequest>
    {
        public FindVwZoneSupervisorRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
