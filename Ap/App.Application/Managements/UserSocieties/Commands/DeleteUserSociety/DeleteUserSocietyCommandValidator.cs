#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserSocieties.Commands.DeleteUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserSocietyCommandValidator 
        : AbstractValidator<DeleteUserSocietyCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserSocietyCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
