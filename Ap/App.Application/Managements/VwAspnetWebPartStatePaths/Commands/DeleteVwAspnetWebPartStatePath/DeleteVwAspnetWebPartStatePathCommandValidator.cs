#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Commands.DeleteVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetWebPartStatePathCommandValidator 
        : AbstractValidator<DeleteVwAspnetWebPartStatePathCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetWebPartStatePathCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
