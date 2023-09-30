#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Commands.DeleteVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetWebPartStateUserCommandValidator 
        : AbstractValidator<DeleteVwAspnetWebPartStateUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetWebPartStateUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
