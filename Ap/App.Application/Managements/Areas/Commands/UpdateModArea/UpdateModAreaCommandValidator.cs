#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Commands.UpdateModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModAreaCommandValidator 
        : AbstractValidator<UpdateModAreaCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModAreaCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModArea, e => e.Name)
            //     );
        }
    }
}
