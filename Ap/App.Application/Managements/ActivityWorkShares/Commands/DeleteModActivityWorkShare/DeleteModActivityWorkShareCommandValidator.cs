#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.DeleteModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModActivityWorkShareCommandValidator 
        : AbstractValidator<DeleteModActivityWorkShareCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModActivityWorkShareCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
