#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Queries.FindVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberSummaryRequestValidator 
        : AbstractValidator<FindVwMemberSummaryRequest>
    {
        public FindVwMemberSummaryRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
