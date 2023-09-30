#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Classs.ModClasss.Commands.DeleteModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModClassCommandValidator 
        : AbstractValidator<DeleteModClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModClassCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
