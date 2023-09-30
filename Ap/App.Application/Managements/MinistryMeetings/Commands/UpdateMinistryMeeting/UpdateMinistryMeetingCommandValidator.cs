#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetings.Commands.UpdateMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryMeetingCommandValidator 
        : AbstractValidator<UpdateMinistryMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryMeeting, e => e.Name)
            //     );
        }
    }
}
