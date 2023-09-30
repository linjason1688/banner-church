#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Commands.DeleteAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetPersonalizationPerUserCommandValidator 
        : AbstractValidator<DeleteAspnetPersonalizationPerUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetPersonalizationPerUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
