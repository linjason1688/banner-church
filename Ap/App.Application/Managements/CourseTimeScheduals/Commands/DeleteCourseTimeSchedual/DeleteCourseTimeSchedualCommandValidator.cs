#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseTimeSchedules.Commands.DeleteCourseTimeSchedule
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseTimeScheduleCommandValidator 
        : AbstractValidator<DeleteCourseTimeScheduleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseTimeScheduleCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
