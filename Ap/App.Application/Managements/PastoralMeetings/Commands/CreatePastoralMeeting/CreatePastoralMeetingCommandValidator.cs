#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.PastoralMeetings.Commands.CreatePastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralMeetingCommandValidator 
        : AbstractValidator<CreatePastoralMeetingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.PastoralMeeting, e => e.Name)
            //     );
        }
    }
}
