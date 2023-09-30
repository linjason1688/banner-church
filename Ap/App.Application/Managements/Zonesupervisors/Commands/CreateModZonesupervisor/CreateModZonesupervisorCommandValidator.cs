#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Zonesupervisors.ModZonesupervisors.Commands.CreateModZonesupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModZonesupervisorCommandValidator 
        : AbstractValidator<CreateModZonesupervisorCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModZonesupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZonesupervisor, e => e.Name)
            //     );
        }
    }
}
