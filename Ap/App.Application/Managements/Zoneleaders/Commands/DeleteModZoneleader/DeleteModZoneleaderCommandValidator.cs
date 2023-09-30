#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.DeleteModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModZoneleaderCommandValidator 
        : AbstractValidator<DeleteModZoneleaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModZoneleaderCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
