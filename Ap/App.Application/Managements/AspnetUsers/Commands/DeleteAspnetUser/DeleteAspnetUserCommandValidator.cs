#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsers.Commands.DeleteAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetUserCommandValidator 
        : AbstractValidator<DeleteAspnetUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
