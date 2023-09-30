#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Queries.QueryAspnetWebeventEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetWebeventEventRequestValidator 
        : AbstractValidator<QueryAspnetWebeventEventRequest>
    {
        public QueryAspnetWebeventEventRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
