#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Commands.UpdateVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMemberMinisterCommandValidator 
        : AbstractValidator<UpdateVwMemberMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMemberMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberMinister, e => e.Name)
            //     );
        }
    }
}
