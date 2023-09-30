#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Commands.UpdateModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberInTagCommandValidator 
        : AbstractValidator<UpdateModMemberInTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberInTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberInTag, e => e.Name)
            //     );
        }
    }
}
