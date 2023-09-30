#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.UpdateModActivityWorkShare
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModActivityWorkShareCommandValidator 
        : AbstractValidator<UpdateModActivityWorkShareCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModActivityWorkShareCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivityWorkShare, e => e.Name)
            //     );
        }
    }
}
