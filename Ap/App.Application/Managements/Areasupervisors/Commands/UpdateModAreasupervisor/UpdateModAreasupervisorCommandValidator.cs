#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.UpdateModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModAreasupervisorCommandValidator 
        : AbstractValidator<UpdateModAreasupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModAreasupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModAreasupervisor, e => e.Name)
            //     );
        }
    }
}
