#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Commands.DeleteModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberLogCommandValidator 
        : AbstractValidator<DeleteModMemberLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberLogCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
