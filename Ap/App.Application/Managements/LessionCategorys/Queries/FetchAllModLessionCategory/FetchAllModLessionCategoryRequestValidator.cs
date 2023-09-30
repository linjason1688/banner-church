#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Queries.FetchAllModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLessionCategoryRequestValidator 
        : AbstractValidator<FetchAllModLessionCategoryRequest>
    {
        public FetchAllModLessionCategoryRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
