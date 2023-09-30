#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwExpGroups.Commands.CreateVwExpGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwExpGroupCommandValidator 
        : AbstractValidator<CreateVwExpGroupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwExpGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwExpGroup, e => e.Name)
            //     );
        }
    }
}
