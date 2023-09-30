#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistrySchedules.Commands.DeleteMinistrySchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryScheduleCommandValidator 
        : AbstractValidator<DeleteMinistryScheduleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryScheduleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
