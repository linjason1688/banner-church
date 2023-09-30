#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwGroups.Commands.DeleteVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwGroupCommandValidator 
        : AbstractValidator<DeleteVwGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwGroupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
