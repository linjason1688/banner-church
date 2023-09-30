#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberTags.Commands.UpdateVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMemberTagCommandValidator 
        : AbstractValidator<UpdateVwMemberTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMemberTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberTag, e => e.Name)
            //     );
        }
    }
}
