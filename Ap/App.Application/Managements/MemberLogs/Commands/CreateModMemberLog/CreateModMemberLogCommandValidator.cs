#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Commands.CreateModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberLogCommandValidator 
        : AbstractValidator<CreateModMemberLogCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberLogCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberLog, e => e.Name)
            //     );
        }
    }
}
