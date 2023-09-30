#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderRecords.Queries.QueryVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwOrderRecordRequestValidator 
        : AbstractValidator<QueryVwOrderRecordRequest>
    {
        public QueryVwOrderRecordRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
