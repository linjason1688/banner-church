#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.CreateModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMinisterGroupCommandValidator 
        : AbstractValidator<CreateModMinisterGroupCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMinisterGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMinisterGroup, e => e.Name)
            //     );
        }
    }
}
