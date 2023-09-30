#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Commands.DeleteModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMinisterCommandValidator 
        : AbstractValidator<DeleteModMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMinisterCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
