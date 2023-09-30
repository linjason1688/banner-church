#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Groupleaders.ModGroupleaders.Commands.CreateModGroupleader
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModGroupleaderCommandValidator 
        : AbstractValidator<CreateModGroupleaderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModGroupleaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModGroupleader, e => e.Name)
            //     );
        }
    }
}
