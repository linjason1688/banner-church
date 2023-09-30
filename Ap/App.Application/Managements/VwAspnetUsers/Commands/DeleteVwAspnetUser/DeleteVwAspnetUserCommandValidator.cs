#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Commands.DeleteVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetUserCommandValidator 
        : AbstractValidator<DeleteVwAspnetUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
