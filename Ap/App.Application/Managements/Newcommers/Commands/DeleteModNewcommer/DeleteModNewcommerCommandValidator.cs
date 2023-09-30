#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Commands.DeleteModNewcommer
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModNewcommerCommandValidator 
        : AbstractValidator<DeleteModNewcommerCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModNewcommerCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
