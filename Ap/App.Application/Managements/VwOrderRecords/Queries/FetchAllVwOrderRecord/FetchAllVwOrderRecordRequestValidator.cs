#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderRecords.Queries.FetchAllVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwOrderRecordRequestValidator 
        : AbstractValidator<FetchAllVwOrderRecordRequest>
    {
        public FetchAllVwOrderRecordRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
