#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Queries.FetchAllVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMemberSummaryRequestValidator 
        : AbstractValidator<FetchAllVwMemberSummaryRequest>
    {
        public FetchAllVwMemberSummaryRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
