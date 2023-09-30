#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.CreateModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassTimeCommandValidator 
        : AbstractValidator<CreateModMemberClassTimeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClassTime, e => e.Name)
            //     );
        }
    }
}
