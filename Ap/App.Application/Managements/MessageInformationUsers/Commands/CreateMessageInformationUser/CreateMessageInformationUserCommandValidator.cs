#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MessageInformationUsers.Commands.CreateMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMessageInformationUserCommandValidator 
        : AbstractValidator<CreateMessageInformationUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMessageInformationUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MessageInformationUser, e => e.Name)
            //     );
        }
    }
}
