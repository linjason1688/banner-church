#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Areas.ModAreas.Commands.CreateModArea
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModAreaCommandValidator 
        : AbstractValidator<CreateModAreaCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModAreaCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModArea, e => e.Name)
            //     );
        }
    }
}
