#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.UpdateModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberClassDayTermCommandValidator 
        : AbstractValidator<UpdateModMemberClassDayTermCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberClassDayTermCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClassDayTerm, e => e.Name)
            //     );
        }
    }
}
