#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Commands.DeleteModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModAreaCommandValidator 
        : AbstractValidator<DeleteModAreaCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModAreaCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
