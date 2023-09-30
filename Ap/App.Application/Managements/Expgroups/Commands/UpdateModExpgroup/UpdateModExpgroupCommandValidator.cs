#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Commands.UpdateModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModExpgroupCommandValidator 
        : AbstractValidator<UpdateModExpgroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModExpgroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModExpgroup, e => e.Name)
            //     );
        }
    }
}
