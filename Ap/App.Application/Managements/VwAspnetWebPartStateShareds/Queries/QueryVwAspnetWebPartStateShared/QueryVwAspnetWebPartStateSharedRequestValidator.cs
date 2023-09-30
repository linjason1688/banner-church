#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateShareds.Queries.QueryVwAspnetWebPartStateShared
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetWebPartStateSharedRequestValidator 
        : AbstractValidator<QueryVwAspnetWebPartStateSharedRequest>
    {
        public QueryVwAspnetWebPartStateSharedRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
