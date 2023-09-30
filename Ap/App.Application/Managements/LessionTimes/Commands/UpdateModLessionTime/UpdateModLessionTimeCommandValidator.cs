#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Commands.UpdateModLessionTime
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModLessionTimeCommandValidator 
        : AbstractValidator<UpdateModLessionTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModLessionTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionTime, e => e.Name)
            //     );
        }
    }
}
