#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetings.Commands.DeleteMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryMeetingCommandValidator 
        : AbstractValidator<DeleteMinistryMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryMeetingCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
