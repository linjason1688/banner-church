#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.UpdateModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModZonesupervisorCommandValidator 
        : AbstractValidator<UpdateModZonesupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModZonesupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZonesupervisor, e => e.Name)
            //     );
        }
    }
}
