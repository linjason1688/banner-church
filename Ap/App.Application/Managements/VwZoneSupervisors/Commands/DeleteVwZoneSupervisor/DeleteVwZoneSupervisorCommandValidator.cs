#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Commands.DeleteVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwZoneSupervisorCommandValidator 
        : AbstractValidator<DeleteVwZoneSupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwZoneSupervisorCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
