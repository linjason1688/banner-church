#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Commands.DeletePastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePastoralMeetingUserCommandValidator 
        : AbstractValidator<DeletePastoralMeetingUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeletePastoralMeetingUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
