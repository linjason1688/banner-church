#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.DeleteModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberMinisterCommandValidator 
        : AbstractValidator<DeleteModMemberMinisterCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberMinisterCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
