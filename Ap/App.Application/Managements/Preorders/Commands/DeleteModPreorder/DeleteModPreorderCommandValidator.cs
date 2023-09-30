#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Commands.DeleteModPreorder
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModPreorderCommandValidator 
        : AbstractValidator<DeleteModPreorderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModPreorderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
