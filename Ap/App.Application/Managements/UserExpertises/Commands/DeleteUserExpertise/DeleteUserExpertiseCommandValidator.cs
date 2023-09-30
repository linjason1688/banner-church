#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserExpertises.Commands.DeleteUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserExpertiseCommandValidator 
        : AbstractValidator<DeleteUserExpertiseCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserExpertiseCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
