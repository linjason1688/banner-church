#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.UpdateModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModLessionCategoryCommandValidator 
        : AbstractValidator<UpdateModLessionCategoryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModLessionCategoryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionCategory, e => e.Name)
            //     );
        }
    }
}
