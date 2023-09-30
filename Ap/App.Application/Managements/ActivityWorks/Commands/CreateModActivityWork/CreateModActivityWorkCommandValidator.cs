#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.CreateModActivityWork
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkCommandValidator 
        : AbstractValidator<CreateModActivityWorkCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWork, e => e.Name)
            //     );
        }
    }
}
