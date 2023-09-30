#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Commands.UpdateVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetWebPartStatePathCommandValidator 
        : AbstractValidator<UpdateVwAspnetWebPartStatePathCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetWebPartStatePathCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStatePath, e => e.Name)
            //     );
        }
    }
}
