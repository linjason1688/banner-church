#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPaths.Commands.UpdateAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetPathCommandValidator 
        : AbstractValidator<UpdateAspnetPathCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetPathCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPath, e => e.Name)
            //     );
        }
    }
}
