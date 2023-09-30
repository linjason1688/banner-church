#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Commands.DeleteModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModClassDayCommandValidator 
        : AbstractValidator<DeleteModClassDayCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModClassDayCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
