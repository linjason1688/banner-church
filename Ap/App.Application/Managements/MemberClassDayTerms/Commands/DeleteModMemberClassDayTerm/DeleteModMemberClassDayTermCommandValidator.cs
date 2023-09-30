#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.DeleteModMemberClassDayTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberClassDayTermCommandValidator 
        : AbstractValidator<DeleteModMemberClassDayTermCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberClassDayTermCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
