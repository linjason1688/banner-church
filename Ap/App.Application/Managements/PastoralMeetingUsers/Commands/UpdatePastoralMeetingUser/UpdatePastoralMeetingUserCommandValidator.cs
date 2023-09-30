#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Commands.UpdatePastoralMeetingUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePastoralMeetingUserCommandValidator 
        : AbstractValidator<UpdatePastoralMeetingUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdatePastoralMeetingUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.PastoralMeetingUser, e => e.Name)
            //     );
        }
    }
}
