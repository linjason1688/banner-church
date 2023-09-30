#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Queries.FindModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModLessionCategoryRequestValidator 
        : AbstractValidator<FindModLessionCategoryRequest>
    {
        public FindModLessionCategoryRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
