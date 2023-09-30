#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.DeleteModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModAreasupervisorCommandValidator 
        : AbstractValidator<DeleteModAreasupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModAreasupervisorCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
