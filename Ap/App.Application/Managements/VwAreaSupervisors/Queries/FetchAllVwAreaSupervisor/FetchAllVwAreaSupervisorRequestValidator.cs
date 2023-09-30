#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Queries.FetchAllVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwAreaSupervisorRequestValidator 
        : AbstractValidator<FetchAllVwAreaSupervisorRequest>
    {
        public FetchAllVwAreaSupervisorRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
