#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Commands.DeleteMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryRespUserCommandValidator 
        : AbstractValidator<DeleteMinistryRespUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryRespUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
