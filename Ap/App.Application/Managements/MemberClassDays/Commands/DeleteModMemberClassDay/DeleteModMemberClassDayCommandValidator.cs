#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.DeleteModMemberClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModMemberClassDayCommandValidator 
        : AbstractValidator<DeleteModMemberClassDayCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModMemberClassDayCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
