#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Commands.CreateVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStatePathCommandValidator 
        : AbstractValidator<CreateVwAspnetWebPartStatePathCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStatePathCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStatePath, e => e.Name)
            //     );
        }
    }
}
