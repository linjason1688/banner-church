#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.DeleteModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModActivityWorkCommandValidator 
        : AbstractValidator<DeleteModActivityWorkCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModActivityWorkCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
