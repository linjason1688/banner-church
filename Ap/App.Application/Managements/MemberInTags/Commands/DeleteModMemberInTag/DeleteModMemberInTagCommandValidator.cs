#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Commands.DeleteModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberInTagCommandValidator 
        : AbstractValidator<DeleteModMemberInTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberInTagCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
