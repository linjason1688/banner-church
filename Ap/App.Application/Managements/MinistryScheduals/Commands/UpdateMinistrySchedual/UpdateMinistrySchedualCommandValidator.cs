#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.UpdateMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryScheduleCommandValidator 
        : AbstractValidator<UpdateMinistryScheduleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryScheduleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistrySchedule, e => e.Name)
            //     );
        }
    }
}
