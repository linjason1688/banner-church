#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserFamilies.Commands.DeleteUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserFamilyCommandValidator 
        : AbstractValidator<DeleteUserFamilyCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserFamilyCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
