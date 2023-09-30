#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.DeleteModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModZonesupervisorCommandValidator 
        : AbstractValidator<DeleteModZonesupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModZonesupervisorCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
