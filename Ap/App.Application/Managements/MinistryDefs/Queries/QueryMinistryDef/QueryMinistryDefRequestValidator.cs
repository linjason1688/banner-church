#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryDefs.Queries.QueryMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryDefRequestValidator 
        : AbstractValidator<QueryMinistryDefRequest>
    {
        public QueryMinistryDefRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
