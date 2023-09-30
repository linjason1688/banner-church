#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.CreateModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberMinisterCommandValidator 
        : AbstractValidator<CreateModMemberMinisterCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberMinister, e => e.Name)
            //     );
        }
    }
}
