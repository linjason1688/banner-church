#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Commands.UpdateModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberLogCommandValidator 
        : AbstractValidator<UpdateModMemberLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberLog, e => e.Name)
            //     );
        }
    }
}
