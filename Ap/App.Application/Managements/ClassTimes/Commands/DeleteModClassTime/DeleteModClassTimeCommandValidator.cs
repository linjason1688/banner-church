#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Commands.DeleteModClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModClassTimeCommandValidator 
        : AbstractValidator<DeleteModClassTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModClassTimeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
