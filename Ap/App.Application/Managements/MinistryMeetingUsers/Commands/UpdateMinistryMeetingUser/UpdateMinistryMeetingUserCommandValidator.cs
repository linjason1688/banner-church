#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Commands.UpdateMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryMeetingUserCommandValidator 
        : AbstractValidator<UpdateMinistryMeetingUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryMeetingUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryMeetingUser, e => e.Name)
            //     );
        }
    }
}
