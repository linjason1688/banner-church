#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Commands.CreateModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberMinisterLogCommandValidator 
        : AbstractValidator<CreateModMemberMinisterLogCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberMinisterLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberMinisterLog, e => e.Name)
            //     );
        }
    }
}
