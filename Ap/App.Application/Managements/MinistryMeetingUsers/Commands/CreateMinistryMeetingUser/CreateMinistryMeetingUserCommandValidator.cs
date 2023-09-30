#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Commands.CreateMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryMeetingUserCommandValidator 
        : AbstractValidator<CreateMinistryMeetingUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryMeetingUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryMeetingUser, e => e.Name)
            //     );
        }
    }
}
