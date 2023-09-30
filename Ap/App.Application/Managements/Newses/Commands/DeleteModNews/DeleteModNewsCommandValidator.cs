#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Commands.DeleteModNews
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModNewsCommandValidator 
        : AbstractValidator<DeleteModNewsCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModNewsCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
