#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.UpdateModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModActivityWorkCommandValidator 
        : AbstractValidator<UpdateModActivityWorkCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModActivityWorkCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWork, e => e.Name)
            //     );
        }
    }
}
