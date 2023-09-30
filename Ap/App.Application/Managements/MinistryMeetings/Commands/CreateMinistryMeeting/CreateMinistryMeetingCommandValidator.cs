#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryMeetings.Commands.CreateMinistryMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryMeetingCommandValidator 
        : AbstractValidator<CreateMinistryMeetingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryMeeting, e => e.Name)
            //     );
        }
    }
}
