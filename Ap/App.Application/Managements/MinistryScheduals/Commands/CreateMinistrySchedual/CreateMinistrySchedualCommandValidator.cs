#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.CreateMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryScheduleCommandValidator 
        : AbstractValidator<CreateMinistryScheduleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryScheduleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistrySchedule, e => e.Name)
            //     );
        }
    }
}
