#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Zoneleaders.ModZoneleaders.Commands.CreateModZoneleader
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModZoneleaderCommandValidator 
        : AbstractValidator<CreateModZoneleaderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModZoneleaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModZoneleader, e => e.Name)
            //     );
        }
    }
}
