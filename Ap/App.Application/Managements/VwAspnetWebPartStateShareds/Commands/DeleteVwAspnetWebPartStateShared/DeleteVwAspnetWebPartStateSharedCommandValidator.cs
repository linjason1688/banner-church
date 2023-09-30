#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Commands.DeleteVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetWebPartStateSharedCommandValidator 
        : AbstractValidator<DeleteVwAspnetWebPartStateSharedCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetWebPartStateSharedCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
