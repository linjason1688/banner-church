#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Members.ModMembers.Commands.DeleteModMember
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberCommandValidator 
        : AbstractValidator<DeleteModMemberCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
