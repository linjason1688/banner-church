#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Queries.QueryVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwMemberSummaryRequestValidator 
        : AbstractValidator<QueryVwMemberSummaryRequest>
    {
        public QueryVwMemberSummaryRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
