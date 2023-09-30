#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Commands.UpdateVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetWebPartStateSharedCommandValidator 
        : AbstractValidator<UpdateVwAspnetWebPartStateSharedCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetWebPartStateSharedCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStateShared, e => e.Name)
            //     );
        }
    }
}
