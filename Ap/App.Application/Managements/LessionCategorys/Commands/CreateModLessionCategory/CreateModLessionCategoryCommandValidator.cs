#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.CreateModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionCategoryCommandValidator 
        : AbstractValidator<CreateModLessionCategoryCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionCategoryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModLessionCategory, e => e.Name)
            //     );
        }
    }
}
