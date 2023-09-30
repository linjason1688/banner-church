#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.UpdateModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMinisterGroupCommandValidator 
        : AbstractValidator<UpdateModMinisterGroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModMinisterGroupCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMinisterGroup, e => e.Name)
            //     );
        }
    }
}
