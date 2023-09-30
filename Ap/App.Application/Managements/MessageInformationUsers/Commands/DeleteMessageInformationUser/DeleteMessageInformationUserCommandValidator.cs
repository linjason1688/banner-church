#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MessageInformationUsers.Commands.DeleteMessageInformationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMessageInformationUserCommandValidator 
        : AbstractValidator<DeleteMessageInformationUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMessageInformationUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
