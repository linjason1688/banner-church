#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwExpGroups.Commands.DeleteVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwExpGroupCommandValidator 
        : AbstractValidator<DeleteVwExpGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwExpGroupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
