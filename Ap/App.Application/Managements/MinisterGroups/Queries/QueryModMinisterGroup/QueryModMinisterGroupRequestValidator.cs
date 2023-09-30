#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Queries.QueryModMinisterGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMinisterGroupRequestValidator 
        : AbstractValidator<QueryModMinisterGroupRequest>
    {
        public QueryModMinisterGroupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
