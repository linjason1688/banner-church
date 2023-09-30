#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Commands.DeleteModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModGroupleaderCommandValidator 
        : AbstractValidator<DeleteModGroupleaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModGroupleaderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
