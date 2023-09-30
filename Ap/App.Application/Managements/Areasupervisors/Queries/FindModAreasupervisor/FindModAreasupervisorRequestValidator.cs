#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Queries.FindModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModAreasupervisorRequestValidator 
        : AbstractValidator<FindModAreasupervisorRequest>
    {
        public FindModAreasupervisorRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
