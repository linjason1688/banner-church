#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Queries.FetchAllVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwZoneSupervisorRequestValidator 
        : AbstractValidator<FetchAllVwZoneSupervisorRequest>
    {
        public FetchAllVwZoneSupervisorRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
