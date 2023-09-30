#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Commands.CreatePastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralMeetingUserCommandValidator 
        : AbstractValidator<CreatePastoralMeetingUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralMeetingUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.PastoralMeetingUser, e => e.Name)
            //     );
        }
    }
}
