#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwMemberMinisters.Commands.CreateVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberMinisterCommandValidator 
        : AbstractValidator<CreateVwMemberMinisterCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberMinisterCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberMinister, e => e.Name)
            //     );
        }
    }
}
