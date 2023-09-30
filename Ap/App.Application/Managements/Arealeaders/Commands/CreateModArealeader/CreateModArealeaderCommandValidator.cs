#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Arealeaders.ModArealeaders.Commands.CreateModArealeader
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModArealeaderCommandValidator 
        : AbstractValidator<CreateModArealeaderCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModArealeaderCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModArealeader, e => e.Name)
            //     );
        }
    }
}
