#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.UpdateModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberMinisterCommandValidator 
        : AbstractValidator<UpdateModMemberMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberMinister, e => e.Name)
            //     );
        }
    }
}
