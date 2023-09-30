#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Areasupervisors.ModAreasupervisors.Commands.CreateModAreasupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModAreasupervisorCommandValidator 
        : AbstractValidator<CreateModAreasupervisorCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModAreasupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModAreasupervisor, e => e.Name)
            //     );
        }
    }
}
