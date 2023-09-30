#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwGroups.Commands.CreateVwGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwGroupCommandValidator 
        : AbstractValidator<CreateVwGroupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwGroup, e => e.Name)
            //     );
        }
    }
}
