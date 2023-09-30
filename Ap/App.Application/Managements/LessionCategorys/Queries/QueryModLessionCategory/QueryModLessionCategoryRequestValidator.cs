#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Queries.QueryModLessionCategory
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModLessionCategoryRequestValidator 
        : AbstractValidator<QueryModLessionCategoryRequest>
    {
        public QueryModLessionCategoryRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
