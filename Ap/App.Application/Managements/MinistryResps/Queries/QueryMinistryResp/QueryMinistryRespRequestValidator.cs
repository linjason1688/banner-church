#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.QueryMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryRespRequestValidator 
        : AbstractValidator<QueryMinistryRespRequest>
    {
        public QueryMinistryRespRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
