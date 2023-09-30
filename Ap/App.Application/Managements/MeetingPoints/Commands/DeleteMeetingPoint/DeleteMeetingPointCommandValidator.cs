#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingPoints.Commands.DeleteMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMeetingPointCommandValidator 
        : AbstractValidator<DeleteMeetingPointCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMeetingPointCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
