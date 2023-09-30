#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStatePaths.Queries.QueryVwAspnetWebPartStatePath
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetWebPartStatePathRequestValidator 
        : AbstractValidator<QueryVwAspnetWebPartStatePathRequest>
    {
        public QueryVwAspnetWebPartStatePathRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
