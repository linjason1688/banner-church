#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Commands.DeletePastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePastoralCommandValidator 
        : AbstractValidator<DeletePastoralCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeletePastoralCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
