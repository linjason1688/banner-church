#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Commands.DeleteAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetPersonalizationAllUserCommandValidator 
        : AbstractValidator<DeleteAspnetPersonalizationAllUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetPersonalizationAllUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
