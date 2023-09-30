#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Commands.UpdateModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModGroupleaderCommandValidator 
        : AbstractValidator<UpdateModGroupleaderCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModGroupleaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModGroupleader, e => e.Name)
            //     );
        }
    }
}
