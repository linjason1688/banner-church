#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetPaths.Commands.CreateAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetPathCommandValidator 
        : AbstractValidator<CreateAspnetPathCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetPathCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPath, e => e.Name)
            //     );
        }
    }
}
