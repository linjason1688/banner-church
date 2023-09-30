#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.CreateModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkShareCommandValidator 
        : AbstractValidator<CreateModActivityWorkShareCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkShareCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWorkShare, e => e.Name)
            //     );
        }
    }
}
