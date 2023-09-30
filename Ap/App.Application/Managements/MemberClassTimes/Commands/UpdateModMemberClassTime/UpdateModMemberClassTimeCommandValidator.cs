#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.UpdateModMemberClassTime
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberClassTimeCommandValidator 
        : AbstractValidator<UpdateModMemberClassTimeCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberClassTimeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClassTime, e => e.Name)
            //     );
        }
    }
}
