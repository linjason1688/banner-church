#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwExpGroups.Commands.UpdateVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwExpGroupCommandValidator 
        : AbstractValidator<UpdateVwExpGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwExpGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwExpGroup, e => e.Name)
            //     );
        }
    }
}
