#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetApplications.Commands.DeleteVwAspnetApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetApplicationCommandValidator 
        : AbstractValidator<DeleteVwAspnetApplicationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetApplicationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
