#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Commands.UpdateMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMessageInformationUserCommandValidator 
        : AbstractValidator<UpdateMessageInformationUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMessageInformationUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MessageInformationUser, e => e.Name)
            //     );
        }
    }
}
