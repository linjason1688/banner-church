#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Classs.ModClasss.Commands.CreateModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassCommandValidator 
        : AbstractValidator<CreateModClassCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModClass, e => e.Name)
            //     );
        }
    }
}
