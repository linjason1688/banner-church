#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Classs.ModClasss.Commands.UpdateModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassCommandValidator 
        : AbstractValidator<UpdateModClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClass, e => e.Name)
            //     );
        }
    }
}
