#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwZoneSupervisors.Commands.CreateVwZoneSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwZoneSupervisorCommandValidator 
        : AbstractValidator<CreateVwZoneSupervisorCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwZoneSupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwZoneSupervisor, e => e.Name)
            //     );
        }
    }
}
