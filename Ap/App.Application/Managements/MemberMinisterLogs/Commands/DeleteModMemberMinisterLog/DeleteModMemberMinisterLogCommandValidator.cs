#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.DeleteModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberMinisterLogCommandValidator 
        : AbstractValidator<DeleteModMemberMinisterLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberMinisterLogCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
