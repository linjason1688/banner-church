#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Commands.UpdateModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModGroupCommandValidator 
        : AbstractValidator<UpdateModGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModGroup, e => e.Name)
            //     );
        }
    }
}
