#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Members.ModMembers.Commands.UpdateModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberCommandValidator 
        : AbstractValidator<UpdateModMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMember, e => e.Name)
            //     );
        }
    }
}
