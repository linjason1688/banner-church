#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Commands.DeleteModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModGroupCommandValidator 
        : AbstractValidator<DeleteModGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModGroupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
