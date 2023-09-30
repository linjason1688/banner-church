#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Groups.ModGroups.Commands.CreateModGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModGroupCommandValidator 
        : AbstractValidator<CreateModGroupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModGroup, e => e.Name)
            //     );
        }
    }
}
