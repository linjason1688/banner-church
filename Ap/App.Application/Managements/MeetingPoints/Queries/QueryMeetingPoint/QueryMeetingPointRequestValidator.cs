#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingPoints.Queries.QueryMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMeetingPointRequestValidator 
        : AbstractValidator<QueryMeetingPointRequest>
    {
        public QueryMeetingPointRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
