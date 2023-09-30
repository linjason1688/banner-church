#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Commands.DeleteMinistryMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryMeetingUserCommandValidator 
        : AbstractValidator<DeleteMinistryMeetingUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryMeetingUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
