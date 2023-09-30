#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Users.Commands.DeleteUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserCommandValidator 
        : AbstractValidator<DeleteUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
