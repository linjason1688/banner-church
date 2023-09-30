#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Commands.DeleteModMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberClassCommandValidator 
        : AbstractValidator<DeleteModMemberClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberClassCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
