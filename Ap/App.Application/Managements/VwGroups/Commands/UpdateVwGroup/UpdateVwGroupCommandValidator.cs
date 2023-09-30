#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwGroups.Commands.UpdateVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwGroupCommandValidator 
        : AbstractValidator<UpdateVwGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwGroup, e => e.Name)
            //     );
        }
    }
}
