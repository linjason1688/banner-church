#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPaths.Commands.DeleteAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetPathCommandValidator 
        : AbstractValidator<DeleteAspnetPathCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetPathCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
