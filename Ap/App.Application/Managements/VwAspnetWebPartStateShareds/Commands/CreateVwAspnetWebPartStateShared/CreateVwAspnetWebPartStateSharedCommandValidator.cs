#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Commands.CreateVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetWebPartStateSharedCommandValidator 
        : AbstractValidator<CreateVwAspnetWebPartStateSharedCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetWebPartStateSharedCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStateShared, e => e.Name)
            //     );
        }
    }
}
