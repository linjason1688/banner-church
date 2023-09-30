#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Commands.DeleteModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMeetingCommandValidator 
        : AbstractValidator<DeleteModMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMeetingCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
