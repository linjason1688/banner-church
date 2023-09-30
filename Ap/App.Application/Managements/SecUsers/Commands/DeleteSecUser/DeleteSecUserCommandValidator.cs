#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUsers.Commands.DeleteSecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSecUserCommandValidator 
        : AbstractValidator<DeleteSecUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSecUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
