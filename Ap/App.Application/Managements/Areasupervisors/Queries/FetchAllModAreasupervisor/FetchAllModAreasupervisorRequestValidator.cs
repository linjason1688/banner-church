#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Queries.FetchAllModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModAreasupervisorRequestValidator 
        : AbstractValidator<FetchAllModAreasupervisorRequest>
    {
        public FetchAllModAreasupervisorRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
