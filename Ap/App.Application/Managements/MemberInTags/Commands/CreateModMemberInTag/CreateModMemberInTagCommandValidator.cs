#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Commands.CreateModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberInTagCommandValidator 
        : AbstractValidator<CreateModMemberInTagCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberInTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberInTag, e => e.Name)
            //     );
        }
    }
}
