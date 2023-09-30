#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Meetings.ModMeetings.Commands.UpdateModMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMeetingCommandValidator 
        : AbstractValidator<UpdateModMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMeeting, e => e.Name)
            //     );
        }
    }
}
