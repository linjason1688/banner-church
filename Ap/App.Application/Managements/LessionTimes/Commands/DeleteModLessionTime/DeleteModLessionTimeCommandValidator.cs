#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Commands.DeleteModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModLessionTimeCommandValidator 
        : AbstractValidator<DeleteModLessionTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModLessionTimeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
