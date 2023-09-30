#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.CreateModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassDayTermCommandValidator 
        : AbstractValidator<CreateModMemberClassDayTermCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassDayTermCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClassDayTerm, e => e.Name)
            //     );
        }
    }
}
