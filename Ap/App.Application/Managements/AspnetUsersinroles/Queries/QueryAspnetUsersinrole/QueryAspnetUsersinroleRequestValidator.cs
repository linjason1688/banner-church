#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Queries.QueryAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetUsersinroleRequestValidator 
        : AbstractValidator<QueryAspnetUsersinroleRequest>
    {
        public QueryAspnetUsersinroleRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
