#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetApplications.Commands.DeleteAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetApplicationCommandValidator 
        : AbstractValidator<DeleteAspnetApplicationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetApplicationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
