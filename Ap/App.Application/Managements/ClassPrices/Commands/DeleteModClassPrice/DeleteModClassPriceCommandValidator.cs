#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassPrices.ModClassPrices.Commands.DeleteModClassPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModClassPriceCommandValidator 
        : AbstractValidator<DeleteModClassPriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModClassPriceCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
