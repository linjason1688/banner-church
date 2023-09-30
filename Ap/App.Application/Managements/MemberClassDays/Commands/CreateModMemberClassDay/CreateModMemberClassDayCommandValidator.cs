#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.CreateModMemberClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassDayCommandValidator 
        : AbstractValidator<CreateModMemberClassDayCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassDayCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClassDay, e => e.Name)
            //     );
        }
    }
}
