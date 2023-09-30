#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetings.Commands.DeletePastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePastoralMeetingCommandValidator 
        : AbstractValidator<DeletePastoralMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeletePastoralMeetingCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
