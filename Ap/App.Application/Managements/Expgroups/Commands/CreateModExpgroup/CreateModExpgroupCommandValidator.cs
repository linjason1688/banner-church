#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Commands.CreateModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModExpgroupCommandValidator 
        : AbstractValidator<CreateModExpgroupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModExpgroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModExpgroup, e => e.Name)
            //     );
        }
    }
}
