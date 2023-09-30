#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Activities.ModActivities.Commands.DeleteModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModActivityCommandValidator 
        : AbstractValidator<DeleteModActivityCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModActivityCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
