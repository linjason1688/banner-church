#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwRollCalls.Commands.DeleteVwRollCall
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwRollCallCommandValidator 
        : AbstractValidator<DeleteVwRollCallCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwRollCallCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
