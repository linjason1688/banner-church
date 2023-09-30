#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Commands.CreateModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMeetingCommandValidator 
        : AbstractValidator<CreateModMeetingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMeeting, e => e.Name)
            //     );
        }
    }
}
