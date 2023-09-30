#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwZoneSupervisors.Commands.UpdateVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwZoneSupervisorCommandValidator 
        : AbstractValidator<UpdateVwZoneSupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwZoneSupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwZoneSupervisor, e => e.Name)
            //     );
        }
    }
}
