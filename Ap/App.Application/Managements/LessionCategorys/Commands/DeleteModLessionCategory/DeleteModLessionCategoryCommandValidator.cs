#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Commands.DeleteModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModLessionCategoryCommandValidator 
        : AbstractValidator<DeleteModLessionCategoryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModLessionCategoryCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
