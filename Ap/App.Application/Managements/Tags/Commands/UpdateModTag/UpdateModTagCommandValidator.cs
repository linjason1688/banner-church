#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Tags.ModTags.Commands.UpdateModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModTagCommandValidator 
        : AbstractValidator<UpdateModTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModTag, e => e.Name)
            //     );
        }
    }
}
