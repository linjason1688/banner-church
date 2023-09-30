#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Commands.DeleteMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryScheduleDetailCommandValidator 
        : AbstractValidator<DeleteMinistryScheduleDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryScheduleDetailCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
