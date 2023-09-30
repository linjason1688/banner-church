#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.PastoralMeetings.Queries.QueryPastoralMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPastoralMeetingRequestValidator 
        : AbstractValidator<QueryPastoralMeetingRequest>
    {
        public QueryPastoralMeetingRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
