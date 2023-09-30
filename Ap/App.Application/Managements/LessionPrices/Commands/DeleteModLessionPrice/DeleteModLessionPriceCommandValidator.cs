#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Commands.DeleteModLessionPrice
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModLessionPriceCommandValidator 
        : AbstractValidator<DeleteModLessionPriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModLessionPriceCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
