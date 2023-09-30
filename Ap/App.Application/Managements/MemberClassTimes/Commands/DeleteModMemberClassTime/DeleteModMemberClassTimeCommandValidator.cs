#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.DeleteModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberClassTimeCommandValidator 
        : AbstractValidator<DeleteModMemberClassTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberClassTimeCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
