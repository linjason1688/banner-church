#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAreaSupervisors.Commands.UpdateVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAreaSupervisorCommandValidator 
        : AbstractValidator<UpdateVwAreaSupervisorCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAreaSupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAreaSupervisor, e => e.Name)
            //     );
        }
    }
}
