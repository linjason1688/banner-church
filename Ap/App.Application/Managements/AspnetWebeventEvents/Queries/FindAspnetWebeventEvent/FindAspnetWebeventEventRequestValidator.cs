#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Queries.FindAspnetWebeventEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetWebeventEventRequestValidator 
        : AbstractValidator<FindAspnetWebeventEventRequest>
    {
        public FindAspnetWebeventEventRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
