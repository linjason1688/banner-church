#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Tags.ModTags.Commands.CreateModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModTagCommandValidator 
        : AbstractValidator<CreateModTagCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModTagCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModTag, e => e.Name)
            //     );
        }
    }
}
