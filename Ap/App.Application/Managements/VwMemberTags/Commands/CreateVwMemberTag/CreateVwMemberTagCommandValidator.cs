#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwMemberTags.Commands.CreateVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberTagCommandValidator 
        : AbstractValidator<CreateVwMemberTagCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberTag, e => e.Name)
            //     );
        }
    }
}
