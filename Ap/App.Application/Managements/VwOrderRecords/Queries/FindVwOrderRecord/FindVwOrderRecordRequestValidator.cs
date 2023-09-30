#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderRecords.Queries.FindVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwOrderRecordRequestValidator 
        : AbstractValidator<FindVwOrderRecordRequest>
    {
        public FindVwOrderRecordRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
