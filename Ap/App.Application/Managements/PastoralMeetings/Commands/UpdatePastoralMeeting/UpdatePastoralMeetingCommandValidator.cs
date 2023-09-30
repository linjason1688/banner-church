#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetings.Commands.UpdatePastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePastoralMeetingCommandValidator 
        : AbstractValidator<UpdatePastoralMeetingCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdatePastoralMeetingCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.PastoralMeeting, e => e.Name)
            //     );
        }
    }
}
