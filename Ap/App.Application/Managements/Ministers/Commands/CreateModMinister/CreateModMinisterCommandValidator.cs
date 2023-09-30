#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Commands.CreateModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMinisterCommandValidator 
        : AbstractValidator<CreateModMinisterCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMinister, e => e.Name)
            //     );
        }
    }
}
