#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.UpdateModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberMinisterLogCommandValidator 
        : AbstractValidator<UpdateModMemberMinisterLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberMinisterLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberMinisterLog, e => e.Name)
            //     );
        }
    }
}
