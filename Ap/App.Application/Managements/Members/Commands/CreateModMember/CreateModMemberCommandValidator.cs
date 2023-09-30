#region

using System;
using App.Application.Common.Interfaces;
using App.Application.Managements.Members.Commands.CreateModMember;
using FluentValidation;


#endregion

namespace App.Application.Managements.Members.ModMembers.Commands.CreateModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberCommandValidator 
        : AbstractValidator<CreateModMemberCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMember, e => e.Name)
            //     );
        }
    }
}
