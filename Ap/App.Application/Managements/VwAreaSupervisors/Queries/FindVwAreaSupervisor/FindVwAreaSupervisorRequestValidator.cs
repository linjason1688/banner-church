#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Queries.FindVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwAreaSupervisorRequestValidator 
        : AbstractValidator<FindVwAreaSupervisorRequest>
    {
        public FindVwAreaSupervisorRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
