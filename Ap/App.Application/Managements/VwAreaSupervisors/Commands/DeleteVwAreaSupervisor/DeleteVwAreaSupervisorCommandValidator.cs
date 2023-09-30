#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Commands.DeleteVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAreaSupervisorCommandValidator 
        : AbstractValidator<DeleteVwAreaSupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAreaSupervisorCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
