#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Rollcalls.ModRollcalls.Commands.DeleteModRollcall
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModRollcallCommandValidator 
        : AbstractValidator<DeleteModRollcallCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModRollcallCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
