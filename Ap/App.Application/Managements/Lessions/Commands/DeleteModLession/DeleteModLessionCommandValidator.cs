#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Lessions.ModLessions.Commands.DeleteModLession
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModLessionCommandValidator 
        : AbstractValidator<DeleteModLessionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModLessionCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
