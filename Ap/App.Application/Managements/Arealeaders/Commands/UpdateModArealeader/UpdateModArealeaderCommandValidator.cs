#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Commands.UpdateModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModArealeaderCommandValidator 
        : AbstractValidator<UpdateModArealeaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModArealeaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModArealeader, e => e.Name)
            //     );
        }
    }
}
