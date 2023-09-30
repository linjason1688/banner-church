#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAreaSupervisors.Commands.CreateVwAreaSupervisor
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAreaSupervisorCommandValidator 
        : AbstractValidator<CreateVwAreaSupervisorCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAreaSupervisorCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAreaSupervisor, e => e.Name)
            //     );
        }
    }
}
