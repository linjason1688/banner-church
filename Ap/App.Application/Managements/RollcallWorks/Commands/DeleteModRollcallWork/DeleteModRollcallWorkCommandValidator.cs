#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.RollcallWorks.ModRollcallWorks.Commands.DeleteModRollcallWork
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModRollcallWorkCommandValidator 
        : AbstractValidator<DeleteModRollcallWorkCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModRollcallWorkCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
