#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserContacts.Commands.DeleteUserContact
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserContactCommandValidator 
        : AbstractValidator<DeleteUserContactCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserContactCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
