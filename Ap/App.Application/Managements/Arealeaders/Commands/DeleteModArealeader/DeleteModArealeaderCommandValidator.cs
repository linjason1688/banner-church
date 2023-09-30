#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Commands.DeleteModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModArealeaderCommandValidator 
        : AbstractValidator<DeleteModArealeaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModArealeaderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
